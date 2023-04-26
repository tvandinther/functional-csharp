using HierarchicalTypes;

string ProcessPayment(Payment payment)
{
    string FormulatePaymentString(string paymentMethodString) => $"Processing payment {payment.Id} of ${payment.Amount} with {paymentMethodString}";

    return FormulatePaymentString(payment.Method switch
    {
        CreditCard {Number: var number, Expiry: var expiry, SecurityCode: var securityCode} =>
            $"credit card {number} expiring {expiry} with security code {securityCode}",
        BankTransfer {AccountNumber: var accountNumber, SortCode: var sortCode} =>
            $"bank transfer with account number {accountNumber} and sort code {sortCode}",
        Bitcoin {Address: var address} => $"bitcoin with address {address}",
        Cash _ => "cash",
        _ => "Unknown payment method"
    });
}

var payment1 = new Payment(14.99m, new CreditCard("1234 5678 9012 3456", "01/21", "123"));
var payment2 = new Payment(14.99m, new Cash());

Console.WriteLine(ProcessPayment(payment1));
Console.WriteLine(ProcessPayment(payment2));
