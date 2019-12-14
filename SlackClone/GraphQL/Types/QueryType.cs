using HotChocolate.Types;

namespace SlackClone.GraphQL
{
    public class QueryType : ObjectType<Queries>
    {
        protected override void Configure(IObjectTypeDescriptor<Queries> descriptor)
        {
            descriptor.Field(t => t.GetUsers()).UseFiltering();
        }
    }
}
