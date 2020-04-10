﻿using System.Collections.Generic;

namespace SlackClone.GraphQL.Mutations
{
    public interface IMutationResponse
    {
        public bool Ok { get; }
        public List<string> Errors { get; }
    }
}
