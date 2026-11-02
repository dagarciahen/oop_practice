public interface IVendingMachineSate
{
    void InsertMoney(VendingMachine VM, decimal amount);
    void SelectProductByCode(VendingMachine VM, string productCode);
    void DispenseProduct(VendingMachine VM);
    string GetStateDescription();
    
}

public abstract class VendingMachineState : IVendingMachineSate
{
    public abstract void InsertMoney(VendingMachine VM, decimal amount);
    public abstract void SelectProductByCode(VendingMachine VM, string productCode);
    public abstract void DispenseProduct(VendingMachine VM);
    public abstract string GetStateDescription();
}

public class NoMoneyInsertedState : VendingMachineState
{
    public override void InsertMoney(VendingMachine VM, decimal amount)
    {
        VM.AddMoney(amount);
        VM.SetState(new MoneyInsertedState());
    }
    public override void SelectProductByCode(VendingMachine VM, string productCode)
    {
throw new InvalidOperationException("Cannot select a product without inserting money");    }
    public override void DispenseProduct(VendingMachine VM)
    {
throw new InvalidOperationException("Cannot select a product without inserting money");    }
    
    public override string GetStateDescription()
    {
        return "No money Inserted State - pleae insert Money to proceeed";
    }

}
public class MoneyInsertedState : VendingMachineState
{
    public override void InsertMoney(VendingMachine VM, decimal amount)
    {
        VM.AddMoney(amount);
    }
    public override void SelectProductByCode(VendingMachine VM, string productCode)
    {
        VM.ChooseProduct(productCode);
        VM.SetState(new DispenseProductState());
    }
    public override void DispenseProduct(VendingMachine VM)
    {
throw new InvalidOperationException("Cannot select a product without inserting money");    }
    
    public override string GetStateDescription()
    {
        return "Money Inserted";
    }
}
public class DispenseProductState : VendingMachineState
{
    public override void InsertMoney(VendingMachine VM, decimal amount)
    {
        throw new InvalidOperationException("Cannot insert money while dispensing a product");
    }

    public override void SelectProductByCode(VendingMachine VM, string productCode)
    {
        throw new InvalidOperationException("Product already selected, confirm transaction to dispense");
    }

    public override void DispenseProduct(VendingMachine VM)
    {
        VM.ConfirmTransaction();               
        VM.SetState(new NoMoneyInsertedState()); 
    }

    public override string GetStateDescription()
    {
        return "Dispensing product";
    }
}