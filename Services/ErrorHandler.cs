using AnnonsApp.Interfaces;
using AnnonsApp.Repository;

namespace AnnonsApp.Services
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly IUserRepo _userRepo = new UserRepo();

        public void LogError(Exception ex)
        {
            if (_userRepo.GetUser(App.currentUserId).Role == 2)
            {
                Console.WriteLine("Något gick fel...");
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
        }
    }
}