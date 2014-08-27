using System;

namespace Domain.Security.Authentication
{
    public class WrongUserNameOrPasswordException : ArgumentException
    {
        public WrongUserNameOrPasswordException() : base("Brukernavn eller passord er feil") { }
    }
}
