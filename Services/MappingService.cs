using AnnonsApp.Interfaces;
using AnnonsApp.Models;
using AnnonsApp.Models.DTOs;
using AnnonsApp.Models.Entities;
using AnnonsApp.Repository;

namespace AnnonsApp.Services
{
    public class MappingService : IMappingService
    {
        private readonly IItemRepo _itemRepo = new ItemRepo();
        private readonly IUserRepo _userRepo = new UserRepo();

        public UserEntity NewAccountModelToUserEntity(NewAccountModel newAccount)
        {
            return new UserEntity()
            {
                Username = newAccount.Username,
                Email = newAccount.Email,
                Password = newAccount.Password,
                City = newAccount.City,
                Zipcode = newAccount.Zipcode,
                Address = newAccount.Address,
                Phone = newAccount.Phone,
            };
        }

        public UserDTO UserEntityToUserDTO(UserEntity userEntity)
        {
            return new UserDTO()
            {
                Username = userEntity.Username,
                Email = userEntity.Email,
                City = userEntity.City,
                Zipcode = userEntity.Zipcode,
                Address = userEntity.Address,
                Phone = userEntity.Phone
            };
        }

        public ItemDTO ItemEntityToItemDTO(ItemEntity itemEntity)
        {
            return new ItemDTO()
            {
                Id = itemEntity.Id,
                Title = itemEntity.Title,
                Description = itemEntity.Description,
                Price = itemEntity.Price,
                Category = _itemRepo.GetCategory(itemEntity.Category_Id).Name,
                Username = _userRepo.GetUser(itemEntity.User_Id).Username
            };
        }

        public List<ItemDTO> ItemEntityToItemDTO(List<ItemEntity> itemEntities)
        {
            List<ItemDTO> itemDTOs = [];

            foreach (var item in itemEntities)
            {
                itemDTOs.Add(ItemEntityToItemDTO(item));
            }

            return itemDTOs;
        }

        public ItemEntity ItemDTOToItemEntity(ItemDTO itemDTO)
        {
            return new ItemEntity()
            {
                Id = itemDTO.Id,
                Title = itemDTO.Title,
                Description = itemDTO.Description,
                Price = itemDTO.Price,
                Category_Id = _itemRepo.GetCategory(itemDTO.Category).Id,
                User_Id = _userRepo.GetUser(itemDTO.Username).Id
            };
        }
    }
}