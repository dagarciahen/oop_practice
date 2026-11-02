public class Order
{
    private readonly List<Ticket> _tickets = new();

    public DateTime OrderTime {get;}
    
    public Order(DateTime orderTime) => orderTime = OrderTime;
    
    public void addTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public decimal getTotalPrice()
    {
        decimal price = 0;
        foreach(Ticket ticket in _tickets)
        {
            price += ticket.Price;
        }
        return price;
    }
}