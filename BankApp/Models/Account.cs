namespace BankAppUsingController.Models;

public class Account
{
    public int AccountNumber { get; set; }

    public string AccountHolderName { get; set; } = string.Empty;

    public int CurrentBalance { get; set; }

}
