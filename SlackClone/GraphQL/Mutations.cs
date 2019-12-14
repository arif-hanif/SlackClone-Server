using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SlackClone.Models;

namespace SlackClone.GraphQL
{
    public class Mutations
    {
        private readonly SlackCloneDbContext _slackCloneDbContext;

        public Mutations(SlackCloneDbContext dbContext)
        {
            _slackCloneDbContext = dbContext;
        }

        public async Task<User> InsertUser(User user)
        {
            await _slackCloneDbContext.Users.InsertOneAsync(user);

            return user;
        }

        public async Task<string> DeleteUser(string id)
        {
            await _slackCloneDbContext.Users.DeleteOneAsync(i => i.Id == id);
            return "ok";
        }

        public async Task<string> UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq("Id", user.Id);

            await _slackCloneDbContext.Users.UpdateOneAsync(filter, user);
        }
    }
}
