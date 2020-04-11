using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SlackClone.Models;

namespace SlackClone.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class UserMutations
    {
        public async Task<InsertMutationResponse<User>> InsertUser(
            InsertUserInput input,
            [Service]SlackCloneDbContext dbContext,
            CancellationToken cancellationToken)
        {
            var ok = false;
            var errors = new List<string>();

            try
            {
                string salt = Guid.NewGuid().ToString("N");

                using var sha = SHA512.Create();
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input.Password + salt));

                Guid personId = Guid.NewGuid();

                var user = new User
                {
                    Email = input.Email,
                    PasswordHash = Convert.ToBase64String(hash),
                    Salt = salt,
                    DisplayName = input.DisplayName,
                    FirstName = input.FirstName,
                    LastName = input.LastName
                };

                dbContext.Users.Add(user);

                await dbContext.SaveChangesAsync(cancellationToken);
                ok = true;
                return new InsertMutationResponse<User>(errors, ok, user);
            }
            catch (DbUpdateException e)
            {
                errors.Add($"DbUpdateException error details - {e?.InnerException?.Message}");
            }
            return new InsertMutationResponse<User>(errors, ok, null);
        }
    }
}