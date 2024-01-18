using AnnonsApp.Models.DTOs;

namespace AnnonsApp.Models.ViewModels
{
    public class DeleteItemViewModel
    {
        public List<ItemDTO> Items { get; set; }

        public DeleteItemViewModel(List<ItemDTO>? items = null)
        {
            Items = items ?? [];
        }
    }
}