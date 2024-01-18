namespace AnnonsApp.Models.ViewModels
{
    public class GetCategoryViewModel
    {
        public List<Category> Categories { get; set; }

        public GetCategoryViewModel(List<Category>? categories = null)
        {
            Categories = categories ?? [];
        }
    }
}