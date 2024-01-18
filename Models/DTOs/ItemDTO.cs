namespace AnnonsApp.Models.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}