using HotChocolate.Types;

namespace SlackClone.GraphQL
{
    public class QueryType : ObjectType<QueryService>
    {
        protected override void Configure(IObjectTypeDescriptor<QueryService> descriptor)
        {
            descriptor.Name("Queries");
            descriptor.Field(t => t.GetUsers()).UseFiltering();
        }
    }
}
