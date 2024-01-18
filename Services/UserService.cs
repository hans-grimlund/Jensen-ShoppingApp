using AnnonsApp.Interfaces;
using AnnonsApp.Models;
using AnnonsApp.Repository;

namespace AnnonsApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo = new UserRepo();

        public Status VerifyNewAccount(NewAccountModel model)
        {
            // Username

            if (model.Username == string.Empty || model.Username == "")
                return Status.InvalidUsername;
            if (model.Username.Length < 4)
                return Status.UsernameTooShort;
            if (!_userRepo.UsernameAvalible(model.Username))
                return Status.UsernameInUse;


            // Email

            if (model.Email == string.Empty || model.Email == "" || model.Email.Length < 4 || !model.Email.Contains('@'))
                return Status.InvalidEmail;
            if (!_userRepo.EmailAvalible(model.Email))
                return Status.EmailInUse;

            
            // Password

            if (model.Password == string.Empty || model.Password == "")
                return Status.InvalidPassword;
            if (model.Password.Length < 6)
                return Status.PasswordTooShort;
            if (model.Password != model.PasswordRepeat)
                return Status.PasswordsNoMatch;


            // Phonenumber

            if (model.Phone.Length > 12)
                return Status.InvalidPhonenumber;
            
            return Status.Success;
        }
    }
}