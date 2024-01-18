namespace AnnonsApp.Models.ViewModels
{
    public class NewItemViewModel
    {
        public List<Category> Categories { get; set; }

        public NewItemViewModel(List<Category>? categories = null)
        {
            Categories = categories ?? [];
        }
    }
}