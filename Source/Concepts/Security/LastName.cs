using Bifrost.Concepts;

namespace Concepts.Security
{
    public class LastName : ConceptAs<string>
    {
        public static implicit operator LastName(string name)
        {
            return new LastName { Value = name };
        } 
    }
}