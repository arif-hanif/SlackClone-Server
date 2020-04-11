using System.Linq;
using HotChocolate;
using HotChocolate.Execution;
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
        public IQueryable<User> GetMe(
                [Service] SlackCloneDbContext dbContext)
        {
            try
            {
                return dbContext.Users.Where(user => user.Email == "test");
            }
            catch
            {
                throw new QueryException(
                                    ErrorBuilder.New()
                                        .SetMessage("The specified password is invalid.")
                                        .SetCode("INVALID_PASSWORD")
                                        .Build());
            }
        }

    }
}