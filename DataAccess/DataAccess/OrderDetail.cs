namespace DataAccess.DataAccess
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}