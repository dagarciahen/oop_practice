public class Order
{
    public DateTime OrderDate {get;}

    private readonly List<Ticket> _tickets = new();
    
    public Order(DateTime orderDate)
    {
        OrderDate = orderDate;
    }
    
    public void addTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }
    
    public decimal calculatePrice()
    {
        decimal price = 0m;
        foreach(Ticket ticket in _tickets)
        {
            price += ticket.Price;
            
        }
        return price;
    }

}