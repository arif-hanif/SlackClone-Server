using HotChocolate.Types;

namespace SlackClone.GraphQL
{
    public class MutationType : ObjectType<MutationService>
    {
        protected override void Configure(IObjectTypeDescriptor<MutationService> descriptor)
        {
            descriptor.Name("Mutations");
            descriptor.Field(t => t.SignIn(default));
        }
    }
}
