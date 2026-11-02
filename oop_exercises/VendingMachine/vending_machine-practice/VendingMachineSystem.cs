public class VendingMachine
{
    public string MachineId {get;}
    private List<Transaction> _transactionsHistory = new();
    private PaymentProcessor _paymentProcessor = new();
    private InventoryManager _inventoryManager = new();
    private Transaction _currentTransaction = new();

    private VendingMachineState _currentState;

    public VendingMachine(string machineId)
    {
        MachineId = machineId;
        _currentState = new NoMoneyInsertedState(); 
    }
    
    public void SetState(VendingMachineState state)
    {
        _currentState = state;
    }
    

    public void SetRack(Dictionary<string, Rack> racks)
    {
        _inventoryManager.UpdateRacks(racks);
    }
    public void AddMoney(decimal amount)
    {
        _paymentProcessor.AddBalance(amount);
    }
    public void ChooseProduct(string rackCode)
    {
        Product product = _inventoryManager.GetProductInRack(rackCode);
        Rack rack = _inventoryManager.GetRack(rackCode);
        _currentTransaction.SetRack(rack);
        _currentTransaction.SetProduct(product);

    }
    
    private void ValidateTransaction()
    {
        if (_currentTransaction.Product is null)
        {
            throw new InvalidateTransactionException("Not enough product in inventory");
        } else if (_paymentProcessor.GetBalance() < _currentTransaction.Product.UnitPrice)
        {
            throw new InvalidateTransactionException("Money is insufficient");
        } else if (_currentTransaction.Product == null)
        {
            throw new InvalidateTransactionException("Invalid Product selection");
        }


    }
    public Transaction ConfirmTransaction()
    {
        ValidateTransaction();
        //charge customer
        _paymentProcessor.ChargeUser(_currentTransaction.Product.UnitPrice);
        //dispense product
        _inventoryManager.DispenseProductFromRack(_currentTransaction.Rack);
        //Give change
        _currentTransaction.SetTotalAmount(_paymentProcessor.GiveRest());
        //add tranasaction to history
        _transactionsHistory.Add(_currentTransaction);
        Transaction completed = _currentTransaction;
        _currentTransaction = new Transaction();
        return completed;

    }
    
    public IReadOnlyList<Transaction> GetTransactionsHistory()
    {
        return _transactionsHistory.AsReadOnly();
    }

    public void CancelTransaction()
    {
        _paymentProcessor.GiveRest();
        _currentTransaction = new Transaction();

    }

    public InventoryManager GetInventoryManager()
    {
        return _inventoryManager;
    }
    public PaymentProcessor GetPaymentProcessor()
    {
        return _paymentProcessor;
    }
}
