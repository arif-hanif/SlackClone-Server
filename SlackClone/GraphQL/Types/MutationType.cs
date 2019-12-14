using HotChocolate.Types;

namespace SlackClone.GraphQL
{
    public class MutationType : ObjectType<Mutations>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutations> descriptor)
        {
            descriptor.Field(t => t.CreateUser(default));
        }
    }
}
