using AnnonsApp.Models.DTOs;

namespace AnnonsApp.Models.ViewModels
{
    public class EditItemViewModel
    {
        public List<ItemDTO> Items { get; set; }

        public EditItemViewModel(List<ItemDTO>? items = null)
        {
            Items = items ?? [];
        }
    }
}