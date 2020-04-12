using System.Linq;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using SlackClone.Models;
using Microsoft.EntityFrameworkCore;

namespace SlackClone.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class UserQueries
    {
        /// <summary>
        /// Gets the currently logged in user.
        /// </summary>
        // [Authorize]
        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<User> GetMe(
                [GlobalState]string currentUserEmail,
                [Service] SlackCloneDbContext dbContext)
        {

            return dbContext.Users.Where(user => user.Email == currentUserEmail);
        }
    }
}