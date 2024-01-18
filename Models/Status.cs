namespace AnnonsApp.Models
{
    public enum Status
    {
        InvalidUsername,
        UsernameInUse,
        UsernameTooShort,
        UsernameNotFound,
        InvalidEmail,
        EmailInUse,
        InvalidPassword,
        PasswordTooShort,
        PasswordsNoMatch,
        WrongPassword,
        InvalidPhonenumber,
        Error,
        None,
        Success
    }
}