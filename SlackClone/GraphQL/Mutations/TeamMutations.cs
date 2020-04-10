using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using SlackClone.Models;

namespace SlackClone.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class TeamMutations
    {
        public async Task<InsertMutationResponse<Team>> CreateTeam(
            CreateTeamInput input,
            [Service]SlackCloneDbContext dbContext,
            CancellationToken cancellationToken)
        {
            var ok = false;
            var errors = new List<string>();

            if (string.IsNullOrEmpty(input.Name))
            {
                errors.Add("teamName can not be empty");
                return new InsertMutationResponse<Team>(errors, ok, null);
            }

            var team = new Team()
            {
                Name = input.Name,
                Description = input.Description
            };

            dbContext.Teams.Add(team);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new InsertMutationResponse<Team>();
        }
    }
}
