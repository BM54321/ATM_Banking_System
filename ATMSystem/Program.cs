using System.Security.Principal;

namespace ATMSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Account> acc = new List<Account>();

            //pre-defined accounts
            Account acc1 = new Account("James Mark", "1111", "123456", 5670);
            Account acc2 = new Account("Axel Piamonte", "1222", "234567", 15670);
            Account acc3 = new Account("John Paul", "1333", "345678", 6708);
            acc.Add(acc1);
            acc.Add(acc2);
            acc.Add(acc3);
            //=====================================================================

            ATM n = new ATM();
            n.setAdmin("admin", "123");
            n.startUp(acc);
        }
    }
}
