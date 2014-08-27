using Bifrost.Concepts;

namespace Concepts.Security
{
    public class FirstName : ConceptAs<string>
    {
        public static implicit operator FirstName(string name)
        {
            return new FirstName { Value = name };
        } 
    }
}