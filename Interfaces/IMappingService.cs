using AnnonsApp.Models;
using AnnonsApp.Models.DTOs;
using AnnonsApp.Models.Entities;

namespace AnnonsApp.Interfaces
{
    public interface IMappingService
    {
        UserEntity NewAccountModelToUserEntity(NewAccountModel newAccount);
        UserDTO UserEntityToUserDTO(UserEntity userEntity);
        ItemDTO ItemEntityToItemDTO(ItemEntity itemEntity);
        List<ItemDTO> ItemEntityToItemDTO(List<ItemEntity> itemEntities);
        ItemEntity ItemDTOToItemEntity(ItemDTO itemDTO);
    }
}