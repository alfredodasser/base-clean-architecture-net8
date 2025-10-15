namespace CleanArchitecture.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    // Relaciones
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}