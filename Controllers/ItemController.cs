using AnnonsApp.Interfaces;
using AnnonsApp.Models.Entities;
using AnnonsApp.Models.ViewModels;
using AnnonsApp.Repository;
using AnnonsApp.Services;
using AnnonsApp.Views;

namespace AnnonsApp.Controllers
{
    public class ItemController
    {
        private readonly ItemView? _view = new();
        private readonly IUserService _userService = new UserService();
        private readonly IMappingService _mappingService = new MappingService();
        private readonly IUserRepo _userRepo = new UserRepo();
        private readonly IItemRepo _itemRepo = new ItemRepo();
        private readonly IErrorHandler _errorHandler = new ErrorHandler();

        public void NewItem()
        {
            try
            {
                NewItemViewModel viewModel = new(_itemRepo.GetAllCategories());
                var newItem = _view.NewItem(viewModel);
                newItem.Category = _itemRepo.GetCategory(Convert.ToInt32(newItem.Category)).Name;
                newItem.Username = _userRepo.GetUser(App.currentUserId).Username;

                if (_view.ConfirmItemUpload(newItem))
                {
                    _itemRepo.AddItem(_mappingService.ItemDTOToItemEntity(newItem));
                }
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void DeleteItem(bool admin = false)
        {
            try
            {
                List<ItemEntity> itemEntities;
                if (admin)
                    itemEntities = _itemRepo.GetAllItems();
                else
                    itemEntities = _itemRepo.GetItemsFromUserId(App.currentUserId);

                if (itemEntities.Count < 1)
                {
                    _view.NoUploadedItems();
                    return;
                }
                DeleteItemViewModel viewModel = new(_mappingService.ItemEntityToItemDTO(itemEntities));
                var itemToDelete = _view.DeleteItem(viewModel, admin: admin);
                if (itemToDelete != 0 && _view.ConfirmItemDelete(_mappingService.ItemEntityToItemDTO(_itemRepo.GetItem(itemToDelete))))
                {
                    _itemRepo.DeleteItem(itemToDelete);
                }
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void EditItem(bool admin = false)
        {
            try
            {
                List<ItemEntity> itemEntities;
                if (admin)
                    itemEntities = _itemRepo.GetAllItems();
                else
                    itemEntities = _itemRepo.GetItemsFromUserId(App.currentUserId);

                if (itemEntities.Count < 1)
                {
                    _view.NoUploadedItems();
                    return;
                }
                EditItemViewModel viewModel = new(_mappingService.ItemEntityToItemDTO(itemEntities));
                var itemToEdit = _view.GetEditItem(viewModel, admin: admin);
                if (itemToEdit != 0)
                {
                    var updatedItem = _view.EditItem(_mappingService.ItemEntityToItemDTO(_itemRepo.GetItem(itemToEdit)));
                    if (updatedItem.Id != 0)
                    {
                        _itemRepo.EditItem(_mappingService.ItemDTOToItemEntity(updatedItem));
                        _view.EditItemSuccessfull();
                    }
                }
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void ShowItems()
        {
            try
            {
                var itemEntities = _itemRepo.GetAllItems();
                ShowItemsViewModel viewModel = new(_mappingService.ItemEntityToItemDTO(itemEntities));
                while (true)
                {
                    var itemId = _view.ShowItems(viewModel);
                    if (itemId != 0)
                        ShowItem(itemId);
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void ShowItem(int id)
        {
            try
            {
                var item = _itemRepo.GetItem(id);
                ShowItemViewModel viewModel = new(_mappingService.ItemEntityToItemDTO(item));
                _view.ShowItem(viewModel);
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void SearchItems()
        {
            try
            {
                var result = _itemRepo.FindItems(_view.GetSearchTerm());
                if (result.Count < 1)
                {
                    _view.NoSearchResults();
                    return;
                }
                ShowItemsViewModel viewModel = new(_mappingService.ItemEntityToItemDTO(result));
                while (true)
                {
                    var itemId = _view.ShowItems(viewModel);
                    if (itemId != 0)
                        ShowItem(itemId);
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void SortByCategory()
        {
            try
            {
                GetCategoryViewModel viewModel = new(_itemRepo.GetAllCategories());
                while (true)
                {
                    var categoryId = _view.GetCategory(viewModel);
                    if (categoryId == 0)
                        return;

                    var items = _itemRepo.GetItemsByCategory(categoryId);
                    if (items.Count == 0)
                        _view.NoSearchResults();
                    else
                    {
                        ShowItemsViewModel viewModel2 = new(_mappingService.ItemEntityToItemDTO(items));
                        while (true)
                        {
                            var itemId = _view.ShowItems(viewModel2);
                            if (itemId == 0)
                                break;

                            ShowItemViewModel viewModel3 = new(_mappingService.ItemEntityToItemDTO(_itemRepo.GetItem(itemId)));
                            _view.ShowItem(viewModel3);
                        }
                    }    
                }
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void AddCategory()
        {
            try
            {
                var category = _view.AddCategory();
                if (_view.ConfirmAddCategory(category))
                    _itemRepo.AddCategory(category);
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void EditCategory()
        {
            try
            {
                var categoryId = _view.GetCategory(new GetCategoryViewModel(_itemRepo.GetAllCategories()));
                var newCategory = _view.EditCategory(_itemRepo.GetCategory(categoryId));
                if (_view.ConfirmEditCategory(newCategory))
                    _itemRepo.EditCategory(newCategory);
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }

        public void DeleteCategory()
        {
            try
            {
                var categoryId = _view.GetCategory(new GetCategoryViewModel(_itemRepo.GetAllCategories()));
                if (_view.ConfirmDeleteCategory(_itemRepo.GetCategory(categoryId)))
                    _itemRepo.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                _errorHandler.LogError(ex);
            }
        }
    }
}