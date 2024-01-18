using AnnonsApp.Interfaces;
using AnnonsApp.Models.ViewModels;
using AnnonsApp.Repository;
using AnnonsApp.Services;
using AnnonsApp.Views;

namespace AnnonsApp.Controllers
{
    public class HomeController
    {
        private HomeView? _view;
        private readonly IUserService _userService = new UserService();
        private readonly IMappingService _mappingService = new MappingService();
        private readonly IUserRepo _userRepo = new UserRepo();
        private readonly IItemRepo _itemRepo = new ItemRepo();
        private readonly IErrorHandler _errorHandler = new ErrorHandler();
        private readonly ItemController _itemController = new();

        public HomeController()
        {
            try
            {
                var currentUserId = _userRepo.GetUser(App.currentUserId);
                HomeViewModel homeViewModel = new(_mappingService.UserEntityToUserDTO(currentUserId), _itemRepo.GetAllItems().Count);
                _view = new(homeViewModel);
            }
            catch (System.Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void Run()
        {
            if (App.currentUserId == 0)
                return;
            
            if (_userRepo.GetUser(App.currentUserId).Role == 2)
            {
                _view.Adminpage();

                if (Int32.TryParse(HelperService.GetUserInput(), out int num))
                {
                    switch (num)
                    {
                        case 1:
                            _itemController.NewItem();
                            break;
                        case 2:
                            _itemController.EditItem(admin: true);
                            break;
                        case 3:
                            _itemController.DeleteItem(admin: true);
                            break;
                        case 4:
                            _itemController.SearchItems();
                            break;
                        case 5:
                            _itemController.ShowItems();  
                            break;
                        case 6:
                            _itemController.SortByCategory();
                            break;
                        case 7:
                            _itemController.AddCategory();
                            break;
                        case 8:
                            _itemController.EditCategory();
                            break;
                        case 9:
                            _itemController.DeleteCategory();
                            break;
                        case 10:
                            App.currentUserId = 0;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                _view.Homepage();

                if (Int32.TryParse(HelperService.GetUserInput(), out int num))
                {
                    switch (num)
                    {
                        case 1:
                            _itemController.NewItem();
                            break;
                        case 2:
                            _itemController.EditItem();
                            break;
                        case 3:
                            _itemController.DeleteItem();
                            break;
                        case 4:
                            _itemController.SearchItems();
                            break;
                        case 5:
                            _itemController.ShowItems();  
                            break;
                        case 6:
                            _itemController.SortByCategory();
                            break;
                        case 7:
                            App.currentUserId = 0;
                            break;
                        case 8:
                        default:
                            break;
                    }
                }
            }
        }
    }
}