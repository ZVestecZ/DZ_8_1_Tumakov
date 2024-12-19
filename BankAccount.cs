using DZ_8_Tumakov;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AccountType
{
    Savings,
    Checking
}

public class BankAccount
{
    private static uint nextAccountNumber = 1;
    private uint accountNumber;
    private decimal balance;
    private AccountType accountType;
    private Queue<BankTransaction> transactions = new Queue<BankTransaction>();
    private bool flag = false;

    // Конструкторы
    public BankAccount()
    {
        GenerateAccountNumber();
        balance = 0;
        accountType = AccountType.Savings;
    }

    public BankAccount(decimal initialBalance)
    {
        GenerateAccountNumber();
        balance = initialBalance;
        accountType = AccountType.Savings;
    }

    public BankAccount(AccountType accountType)
    {
        GenerateAccountNumber();
        balance = 0;
        this.accountType = accountType;
    }

    public BankAccount(decimal initialBalance, AccountType accountType)
    {
        GenerateAccountNumber();
        this.balance = initialBalance;
        this.accountType = accountType;
    }

    public uint AccountNumber { get { return accountNumber; } }
    public decimal Balance
    {
        get { return balance; }
        private set { balance = value; }
    }
    public AccountType AccountType { get { return accountType; } }

    public void PrintInfo()
    {
        Console.WriteLine($"Номер счета: {accountNumber}");
        Console.WriteLine($"Баланс: {balance}");
        Console.WriteLine($"Тип счета: {accountType}");
    }

    public bool Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("Недостаточно средств на счете.");
            return false;
        }
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
        transactions.Enqueue(new BankTransaction(amount));
    }


    public bool TransferTo(BankAccount destinationAccount, decimal amount)
    {
        if (Withdraw(amount))
        {
            destinationAccount.Deposit(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GenerateAccountNumber()
    {
        accountNumber = nextAccountNumber++;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (flag)
            return;

        if (disposing)
        {
            SaveTransactionsToFile();
        }
        flag = true;

    }

    private void SaveTransactionsToFile()
    {
        string filename = $"output_{accountNumber}.txt";
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (BankTransaction transaction in transactions)
            {
                writer.WriteLine($"Время: {transaction.TransactionTime}, Сумма: {transaction.Amount}");
            }
            Console.WriteLine($"Данные о транзакциях записаны в файл: {filename}");
        }
    }

    ~BankAccount()
    {
        Dispose(false);
    }
}