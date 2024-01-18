using AnnonsApp.Models.DTOs;

namespace AnnonsApp.Models.ViewModels
{
    public class ShowItemViewModel
    {
        public ItemDTO Item { get; set; }

        public ShowItemViewModel(ItemDTO? item = null)
        {
            Item = item ?? new();
        }
    }
}