using System;
using System.Collections.Generic;

namespace SlackClone.GraphQL.Mutations
{
    public class InsertMutationResponse<T> : MutationResponse
    {
        public T InsertedObject { get; set; }

        public InsertMutationResponse(
            List<string> errors = null,
            bool ok = false,
            T insertedObject = default) : base(ok, errors)
        {
            InsertedObject = insertedObject;
        }
    }
}
