public class InventoryManager
{
    private  Dictionary<string, Rack> _racks;

    
    public void AddRack(string rackCode, Rack rack)
    {
        _racks[rackCode] = rack;
    }
    public void UpdateRacks(Dictionary<string, Rack> racks)
    {
        _racks = racks;
    }
    public Rack GetRack(string rackCode)
    {
        return _racks[rackCode];
    }
    public Product GetProductInRack(string rackCode)
    {
        return _racks[rackCode].Product;
    }
    public void DispenseProductFromRack(Rack rack)
    {
        rack.Count--;
        
    }

}