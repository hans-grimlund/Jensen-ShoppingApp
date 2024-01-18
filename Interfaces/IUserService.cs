using AnnonsApp.Models;

namespace AnnonsApp.Interfaces
{
    public interface IUserService
    {
        Status VerifyNewAccount(NewAccountModel model);
    }
}