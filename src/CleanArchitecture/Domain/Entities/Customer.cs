namespace CleanArchitecture.Domain.Entities;

public class Customer   
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Relaciones
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}