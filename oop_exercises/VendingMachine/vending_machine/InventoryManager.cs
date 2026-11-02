public class InventoryManager
{
    private Dictionary<string, Rack> _racks = new();

    public void AddRack(string rackId, Rack rack)
    {
        _racks[rackId] = rack;
    }
    
    public void UpdateRacks(Dictionary<string, Rack> racks)
    {
        _racks = racks;
    }
    
    public Rack GetRack(string rackId)
    {
        return _racks[rackId];
    }

    public Product GetProductInRack(string rackCode)
    {
        return _racks[rackCode].Product;
        
    }
    public void DispenseProduct(Rack rack)
    {
        rack.Count--;
    }
    
}