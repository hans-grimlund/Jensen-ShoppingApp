using AnnonsApp.Models.DTOs;
using AnnonsApp.Models.Entities;

namespace AnnonsApp.Interfaces
{
    public interface IUserRepo
    {
        bool UserExists(int id);
        bool UsernameAvalible(string username);
        bool EmailAvalible(string email);
        int AddUser(UserEntity userEntity);
        void DeleteUser(int id);
        void UpdateUser(UserDTO userDTO);
        void ChangePassword(int id, string newPassword);
        UserEntity GetUser(int id);
        UserEntity GetUser(string username);
    }
}