namespace OOProgramming;

public class BankAccount
{
    // Data Members
    private static int accountNumberSeed = 1234567890;
    
    // Properties
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance 
    { 
        get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        } 
    }

    // Constructors
    public BankAccount(string name, decimal initialBalance)
    {
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    //
    private List<Transaction> allTransactions = new List<Transaction>();


    // Methods
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        // enforce initial balance > 0
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of the deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        // enforce withdrawal won't create a negative balance
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal.");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }
}