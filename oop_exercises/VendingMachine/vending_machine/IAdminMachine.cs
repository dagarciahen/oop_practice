public interface IAdminMachine
{
    void SetRacks(Dictionary<string, Rack> racks);
    IReadOnlyList<Transaction> GetTransactionHistory();
    InventoryManager GetInventoryManager();
}
