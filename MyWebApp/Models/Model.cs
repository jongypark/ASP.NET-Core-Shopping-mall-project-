namespace MyWebApp.Models
{
    public class Cart
    {
        public List<CartItems> Items { get; set; } = new List<CartItems>();

        public void AddItem(Product product, int quantity)
        {
            CartItems? line = Items.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartItems
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
                line.Quantity += quantity;
        }

        public void RemoveItem(Product product) => Items.RemoveAll(i => i.Product.Id == product.Id);

        public decimal ComputeTotalValue() => Items.Sum(i => i.Product.Price * i.Quantity);

        public void Clear() => Items.Clear();
    }

    public class CartItems
    {
        public int CartItemsID { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}