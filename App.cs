using AnnonsApp.Controllers;

namespace AnnonsApp
{
    public class App
    {
        public static int currentUserId;
        private StartController? _startController;
        private HomeController? _homeController;

        public void Run()
        {
            while (true)
            {
                _startController = new();
                _startController.Run();

                _homeController = new();
                _homeController.Run();
            }
        }
    }
}