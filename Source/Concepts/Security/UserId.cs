using System;
using Bifrost.Concepts;

namespace Concepts
{
    public class UserId : ConceptAs<Guid>
    {
        public static implicit operator UserId(Guid id)
        {
            return new UserId { Value = id };
        } 
    }
}