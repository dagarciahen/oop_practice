public interface ICustomerMachine
{
    void InsertMoney(decimal amount);
    void ChooseProduct(string rackId);
    Transaction ConfirmTransaction();
    void CancelTransaction();
}
