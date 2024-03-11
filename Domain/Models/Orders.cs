namespace Domain.Models;

public class Orders
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Total { get; set; }
}
