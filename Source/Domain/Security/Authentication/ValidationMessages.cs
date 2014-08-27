namespace Domain.Security.Authentication
{
    public class ValidationMessages
    {
        public virtual string UsernameMustBeSpecified { get { return "You have to specify a username"; } }
        public virtual string UsernameMustBeEMail { get { return "The username must be a valid email"; } }
        public virtual string PasswordMustBeSpecified { get { return "You must specify a password"; } }
    }
}
