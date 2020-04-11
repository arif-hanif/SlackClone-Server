using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SlackClone.Models;

namespace SlackClone.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class TeamMutations
    {
        public async Task<InsertMutationResponse<Team>> CreateTeam(
            InsertTeamInput input,
            [Service]SlackCloneDbContext dbContext,
            CancellationToken cancellationToken)
        {
            var ok = false;
            var errors = new List<string>();

            try
            {
                if (string.IsNullOrEmpty(input.Name))
                {
                    errors.Add("teamName can not be empty");
                }

                var team = new Team()
                {
                    Name = input.Name,
                    Description = input.Description
                };

                dbContext.Teams.Add(team);
                await dbContext.SaveChangesAsync(cancellationToken);
                ok = true;

                return new InsertMutationResponse<Team>(errors, ok, team);
            }
            catch (DbUpdateException e)
            {
                errors.Add($"DbUpdateException error details - {e?.InnerException?.Message}");
            }
            return new InsertMutationResponse<Team>(errors, ok, null);
        }
    }
}
