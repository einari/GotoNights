namespace Concepts.Security
{
    public class ValidationMessages 
    {
        public virtual string FirstNameMustBeSpecified { get { return "First name is required"; } }
        public virtual string LastNameMustBeSpecified { get { return "Last name is required"; } }
        public virtual string UserNameMustBeUnique { get { return "Username is already used"; } }
        public virtual string UsernameMustBeSpecified { get { return "Username is required"; } }
        public virtual string UsernameMustBeEMail { get { return "Username must be an email"; } }
        public virtual string PasswordMustBeSpecified { get { return "You must specify a password"; } }
        public virtual string UserIdCannotBeEmpty { get { return "User Id cannot be empty"; } }

    }
}
