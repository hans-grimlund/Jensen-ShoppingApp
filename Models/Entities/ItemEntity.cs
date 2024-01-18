namespace AnnonsApp.Models.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Category_Id { get; set; }
        public int User_Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}