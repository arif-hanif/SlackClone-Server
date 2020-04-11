using SlackClone.Models;

namespace SlackClone.GraphQL.Mutations
{
    public class LoginResponse
    {
        public LoginResponse(
            User me,
            string token,
            string scheme)
        {
            Me = me;
            Token = token;
            Scheme = scheme;
        }

        public User Me { get; }

        public string Token { get; }

        public string Scheme { get; }
    }
}