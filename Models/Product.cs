namespace RepositoryPattern.Models
{
    public class Product : Entity
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
