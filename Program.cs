using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8_Tumakov
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Задание 9.1
            Console.WriteLine("адание 9.1");
            BankAccount account1 = new BankAccount();
            Console.WriteLine("Счет 1:");
            account1.PrintInfo();

            BankAccount account2 = new BankAccount(1000);
            Console.WriteLine("\nСчет 2:");
            account2.PrintInfo();

            BankAccount account3 = new BankAccount(AccountType.Checking);
            Console.WriteLine("\nСчет 3:");
            account3.PrintInfo();

            BankAccount account4 = new BankAccount(2000, AccountType.Savings);
            Console.WriteLine("\nСчет 4:");
            account4.PrintInfo();

            account4.PrintInfo();
            account4.Withdraw(200);
            account4.Deposit(500);
            account4.PrintInfo();

            Console.WriteLine("Перевод:");
            if (account1.TransferTo(account2, 200))
            {
                Console.WriteLine("Перевод выполнен успешно.");
                account1.PrintInfo();
                account2.PrintInfo();
            }
            else
            {
                Console.WriteLine("Перевод не выполнен.");
            }


            Console.ReadKey();
        }
    }

}
