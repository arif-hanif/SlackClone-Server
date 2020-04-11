using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using SlackClone.Models;

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
                [GlobalState] string currentUserEmail, [Service] SlackCloneDbContext dbContext) =>
            dbContext.Users.Where(t => t.Email == currentUserEmail);
    }
}