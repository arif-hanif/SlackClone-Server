using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using SlackClone.Models;

namespace SlackClone.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class TeamQueries
    {
        [UseFiltering, UseSorting]
        public IQueryable<Team> GetTeams([Service]SlackCloneDbContext dbContext) => dbContext.Teams;
    }
}
