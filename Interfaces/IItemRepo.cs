using AnnonsApp.Models;
using AnnonsApp.Models.Entities;

namespace AnnonsApp.Interfaces
{
    public interface IItemRepo
    {
        void AddItem(ItemEntity item);
        void EditItem(ItemEntity item);
        void DeleteItem(int id);
        ItemEntity GetItem(int id);
        List<ItemEntity> GetItemsFromUserId(int id);
        List<ItemEntity> GetAllItems();
        List<ItemEntity> FindItems(string searchTerm);
        List<ItemEntity> GetItemsByCategory(int categoryId);
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
        List<Category> GetAllCategories();
        Category GetCategory(string name);
        Category GetCategory(int id);
    }
}