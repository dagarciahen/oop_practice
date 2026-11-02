public class VendingMachine2 : ICustomerMachine, IAdminMachine
{
    public string MachineId { get; }
    private readonly List<Transaction> _transactions = new();
    private readonly InventoryManager _inventoryManager = new();
    private readonly PaymentProcessor _paymentProcessor = new();
    private Transaction _currentTransaction;

    public VendingMachine2(string machineId)
    {
        MachineId = machineId;
        _currentTransaction = new Transaction();
    }

    // IAdminMachine
    public void SetRacks(Dictionary<string, Rack> racks)
    {
        _inventoryManager.UpdateRacks(racks);
    }

    // IAdminMachine
    public IReadOnlyList<Transaction> GetTransactionHistory()
    {
        return _transactions.AsReadOnly();
    }

    // IAdminMachine
    public InventoryManager GetInventoryManager()
    {
        return _inventoryManager;
    }

    // ICustomerMachine
    public void InsertMoney(decimal amount)
    {
        _paymentProcessor.AddBalance(amount);
    }

    // ICustomerMachine
    public void ChooseProduct(string rackId)
    {
        Rack rack = _inventoryManager.GetRack(rackId);
        Product product = rack.Product;
        _currentTransaction.SetRack(rack);
        _currentTransaction.SetProduct(product);
    }

    private void ValidateTransaction()
    {
        if (_currentTransaction.Product == null)
        {
            throw new InvalidTransactionException("Invalid Product Selection");
        }
        else if (_currentTransaction.Rack.Count == 0)
        {
            throw new InvalidTransactionException("Inssuficient Product Inventory");
        }
        else if (_paymentProcessor.CurrentBalance < _currentTransaction.Product.UnitPrice)
        {
            throw new InvalidTransactionException("Inssuficient fund");
        }
    }

    // ICustomerMachine
    public Transaction ConfirmTransaction()
    {
        // Step 1 validate before processing
        ValidateTransaction();
        // Step 2 receive money and charge customer - price of item
        _paymentProcessor.ChargePrice(_currentTransaction.Product.UnitPrice);
        // Step 3 give product
        _inventoryManager.DispenseProduct(_currentTransaction.Rack);
        // Step 4 give change
        _currentTransaction.SetTotalAmount(_paymentProcessor.GiveChange());
        _transactions.Add(_currentTransaction);
        Transaction completed = _currentTransaction;
        // Step 5 restart for next
        _currentTransaction = new Transaction();
        return completed;
    }

    // ICustomerMachine
    public void CancelTransaction()
    {
        _paymentProcessor.GiveChange();
        _currentTransaction = new Transaction();
    }
}
