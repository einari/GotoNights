using Bifrost.Concepts;

namespace Concepts.Security
{
    public class Password : ConceptAs<string>
    {
        public static implicit operator Password(string password)
        {
            return new Password { Value = password };
        } 
    }
}