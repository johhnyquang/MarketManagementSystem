namespace MarketManagement.Core.Models
{
    public class CartItemsEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation Properties
        public CartEntity? Cart { get; set; }
        public ProductEntity? Product { get; set; }
    }
}