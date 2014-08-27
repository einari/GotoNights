using Bifrost.Concepts;

namespace Concepts.Security
{
    public class Username : ConceptAs<string>
    {
        public static implicit operator Username(string name)
        {
            return new Username { Value = name };
        } 
    }
}