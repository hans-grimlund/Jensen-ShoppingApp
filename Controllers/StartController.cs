using AnnonsApp.Interfaces;
using AnnonsApp.Services;
using AnnonsApp.Views;
using AnnonsApp.Models;
using AnnonsApp.Repository;
using AnnonsApp.Models.Entities;

namespace AnnonsApp.Controllers
{
    public class StartController
    {
        private readonly StartView _view = new StartView();
        private readonly IMappingService _mappingService = new MappingService();
        private readonly IUserService _userService = new UserService();
        private readonly IUserRepo _userRepo = new UserRepo();
        private readonly IErrorHandler _errorHandler = new ErrorHandler();

        public void Run()
        {
            if (App.currentUserId != 0)
                return;

            var input = _view.Startpage();
            switch (input)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    Login();
                    break;
                default:
                    break;
            }
        }

        private void Login()
        {
            try
            {
                var status = Status.None;
                var loginModel = _view.Loginpage();
                UserEntity? user = null;

                while (true)
                {
                    if (!_userRepo.UsernameAvalible(loginModel.Username))
                    {
                        user = _userRepo.GetUser(loginModel.Username);
                        if (BCrypt.Net.BCrypt.EnhancedVerify(loginModel.Password, user.Password))
                        {
                            status = Status.Success;
                            break;
                        }

                        status = Status.WrongPassword;
                        user = null;
                    }
                    else
                        status = Status.UsernameNotFound;
                    
                    loginModel = _view.Loginpage(status);
                }

                if (status == Status.Success)                    
                {
                    App.currentUserId = user!.Id;
                }
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        private void CreateAccount()
        {
            try
            {
                var newAccount = _view.CreateAccount();
                for (int i = 0; i < 3; i++)
                {
                    var status = _userService.VerifyNewAccount(newAccount);
                    if (status == Status.Success)
                        break;

                    newAccount = _view.CreateAccount(status);
                }

                newAccount.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(newAccount.Password, 13);
                var userEntity = _mappingService.NewAccountModelToUserEntity(newAccount);
                var newUserId = _userRepo.AddUser(userEntity);
                App.currentUserId = newUserId;
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }
    }
}