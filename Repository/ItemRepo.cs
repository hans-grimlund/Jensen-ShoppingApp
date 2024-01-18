using AnnonsApp.Interfaces;
using AnnonsApp.Models;
using AnnonsApp.Models.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AnnonsApp.Repository
{
    public class ItemRepo : IItemRepo
    {
        public void AddItem(ItemEntity item)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Title", item.Title);
            parameters.Add("@Description", item.Description);
            parameters.Add("@Price", item.Price);
            parameters.Add("@Category", item.Category_Id);
            parameters.Add("@UserId", item.User_Id);

            conn.Execute("InsertItem", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void EditItem(ItemEntity item)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", item.Id);
            parameters.Add("@Title", item.Title);
            parameters.Add("@Description", item.Description);
            parameters.Add("@Price", item.Price);

            conn.Execute("UpdateItem", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void DeleteItem(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            conn.Execute("DeleteItem", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public ItemEntity GetItem(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.QueryFirstOrDefault<ItemEntity>("SelectItem", parameters, commandType: System.Data.CommandType.StoredProcedure)!;
        }
        
        public List<ItemEntity> GetItemsFromUserId(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.Query<ItemEntity>("SelectItemsFromUserId", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public List<ItemEntity> GetAllItems()
        {
            using SqlConnection conn = new(ConnectionString.str);
            return conn.Query<ItemEntity>("SelectAllItems", commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public List<ItemEntity> FindItems(string searchTerm)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@SearchTerm", searchTerm);

            return conn.Query<ItemEntity>("SearchItemsByTitle", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public List<ItemEntity> GetItemsByCategory(int categoryId)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", categoryId);

            return conn.Query<ItemEntity>("SelectItemsByCategory", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public void AddCategory(Category category)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Name", category.Name);

            conn.Execute("InsertCategory", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void EditCategory(Category category)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", category.Id);
            parameters.Add("@Name", category.Name);

            conn.Execute("UpdateCategory", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
        
        public void DeleteCategory(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            conn.Execute("DeleteCategory", parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public List<Category> GetAllCategories()
        {
            using SqlConnection conn = new(ConnectionString.str);
            return conn.Query<Category>("SelectAllCategories", commandType: System.Data.CommandType.StoredProcedure).ToList();
        }

        public Category GetCategory(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Id", id);

            return conn.QueryFirstOrDefault<Category>("SelectCategory", parameters, commandType: System.Data.CommandType.StoredProcedure)!;
        }

        public Category GetCategory(string name)
        {
            using SqlConnection conn = new(ConnectionString.str);

            DynamicParameters parameters = new();
            parameters.Add("@Name", name);

            return conn.QueryFirstOrDefault<Category>("SelectCategoryFromName", parameters, commandType: System.Data.CommandType.StoredProcedure)!;
        }
    }
}