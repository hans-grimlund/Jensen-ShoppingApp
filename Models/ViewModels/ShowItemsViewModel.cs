using AnnonsApp.Models.DTOs;

namespace AnnonsApp.Models.ViewModels
{
    public class ShowItemsViewModel
    {
        public List<ItemDTO> Items { get; set; }

        public ShowItemsViewModel(List<ItemDTO>? items = null)
        {
            Items = items ?? [];
        }
    }
}