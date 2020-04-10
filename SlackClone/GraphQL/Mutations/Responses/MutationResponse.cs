using System.Collections.Generic;

namespace SlackClone.GraphQL.Mutations
{
    public class MutationResponse : IMutationResponse
    {
        public bool Ok { get; }
        public List<string> Errors { get; } = new List<string>();

        public MutationResponse(
            bool ok = false,
            List<string> errors = null)
        {
            Ok = ok;
            Errors.AddRange(errors);
        }
    }
}
