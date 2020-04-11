using HotChocolate;

namespace SlackClone.GraphQL.Mutations
{
    public class InsertUserInput
    {
        public InsertUserInput(
            string firstName,
            string lastName,
            string displayName,
            string email,
            string password)
        {
            DisplayName = displayName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        [GraphQLNonNullType]
        public string DisplayName { get; }
        [GraphQLNonNullType]
        public string FirstName { get; }
        [GraphQLNonNullType]
        public string LastName { get; }
        [GraphQLNonNullType]
        public string Email { get; }
        [GraphQLNonNullType]
        public string Password { get; }
    }
}