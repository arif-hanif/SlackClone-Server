namespace SlackClone.GraphQL.Mutations
{
    public class LoginInput
    {
        public LoginInput(
                    string email,
                    string password)
        {
            Email = email;
            Password = password;
        }
        public string Email { get; }
        public string Password { get; }
    }
}