namespace ModelLayer.Model;

public class Order
{
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }

    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Address { get; set; }
    public string? Status { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ReceiverName { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public DateTime? ReceivedDate { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}