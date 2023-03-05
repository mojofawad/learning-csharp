namespace OOProgramming;

// define the class or type
public class BankAccount
{
    // define state and behavior of the class
    // 7 total members of the class

    // These 1 members of the class are data members
    // accountNumberSeed | 

    // These 3 members of the class are properties
    // Number | Owner | Balance
    // properties are data elements that enforce rules
    
    // These 3 members of the class are methods
    // MakeDeposit | MakeWithdrawal | GetAccountHistory
    // methods are blocks of code that performa a single function

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

    //
    // Open a bank account
    // New bank accounts need an initial balance and
    // information about the owner(s) of that account
    //

    // Constructors
    public BankAccount(string name, decimal initialBalance)
    {
        // Identify properties of the object being 
        // constructed by including `this` qualifier 
        // `this` is optional here, but sometimes required
        // this.Owner = name;
        // this.Balance = initialBalance;

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

    // polymorphism concept
    // the `virtual` keyword declares a method in the base class
    // that a derived class may provide a different implementation for
    public virtual void PerformMonthEndTransactions() { }
}