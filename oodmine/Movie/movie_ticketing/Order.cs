public class Order
{
    private readonly List<Ticket> _tickets = new();
    public DateTime OrderDate {get;}

    public Order(DateTime orderDate)
    {
        OrderDate = orderDate;
    }
    
    public void addTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }
    
    public decimal CalculatePrice()
    {
        decimal price = 0;
        foreach(Ticket ticket in _tickets)
        {
            price +=ticket.Price;
        }
        return price;
    }
    
    
}