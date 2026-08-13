namespace E_Commerce.Domain.Entities.Basckets
{
    public class CustomerBasket
    {
        public string Id { get; set; }

        public ICollection<BasketItem> Items { get; set; } = [];
    }
}
