using System;
using HotChocolate;

namespace SlackClone.GraphQL.Mutations
{
    public class InsertTeamInput
    {
        [GraphQLNonNullType]
        public string Name { get; set; }

        [GraphQLNonNullType]
        public string Description { get; set; }
    }
}
