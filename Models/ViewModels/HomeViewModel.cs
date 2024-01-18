using AnnonsApp.Models.DTOs;

namespace AnnonsApp.Models.ViewModels
{
    public class HomeViewModel
    {
        public UserDTO? User { get; set; }
        public int ItemCount { get; set; }

        public HomeViewModel(UserDTO? user = null, int itemCount = 0)
        {
            User = user;
            ItemCount = itemCount;
        }
    }
}