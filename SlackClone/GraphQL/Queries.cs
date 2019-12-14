using SlackClone.Models;
using MongoDB.Driver;
using System.Linq;

namespace SlackClone.GraphQL
{
    public class Queries
    {
        private readonly SlackCloneDbContext _slackCloneDbContext;

        public Queries(SlackCloneDbContext dbContext)
        {
            _slackCloneDbContext = dbContext;
        }

        public IQueryable<User> GetUsers()
        {
            return _slackCloneDbContext.Users.AsQueryable();
        }
    }
}
