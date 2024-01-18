using AnnonsApp.Interfaces;
using AnnonsApp.Models.DTOs;
using AnnonsApp.Models.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AnnonsApp.Repository
{
    public class UserRepo : IUserRepo
    {
        public bool UserExists(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var result = conn.QueryFirstOrDefault<UserEntity>("SelectUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (result != null)
                return true;
            
            return false;
        }

        public bool UsernameAvalible(string username)
        {
            using SqlConnection conn = new(ConnectionString.str);

            var parameters = new DynamicParameters();
            parameters.Add("@Username", username);

            var result = conn.QueryFirstOrDefault<UserEntity>("SelectUserFromUsername", parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
                return true;
            
            return false;
        }
        
        public bool EmailAvalible(string email)
        {
            using SqlConnection conn = new(ConnectionString.str);

            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            var result = conn.QueryFirstOrDefault<UserEntity>("SelectUserFromEmail", parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
                return true;
            
            return false;
        }
        
        public int AddUser(UserEntity userEntity)
        {
            using SqlConnection conn = new(ConnectionString.str);
            return conn.QueryFirst<UserEntity>("InsertUser", userEntity, commandType: System.Data.CommandType.StoredProcedure).Id;
        }
        
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
        
        public void ChangePassword(int id, string newPassword)
        {
            throw new NotImplementedException();
        }
        
        public UserEntity GetUser(int id)
        {
            using SqlConnection conn = new(ConnectionString.str);

            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            return conn.QueryFirstOrDefault<UserEntity>("SelectUser", parameters, commandType: System.Data.CommandType.StoredProcedure)!;
        }
        
        public UserEntity GetUser(string username)
        {
            using SqlConnection conn = new(ConnectionString.str);

            var parameters = new DynamicParameters();
            parameters.Add("@Username", username);

            return conn.QueryFirstOrDefault<UserEntity>("SelectUserFromUsername", parameters, commandType: System.Data.CommandType.StoredProcedure)!;
        }
        
    }
}