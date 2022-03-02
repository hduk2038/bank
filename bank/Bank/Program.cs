using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace BankApplication
{

    public class Program
    {
        private string name, password;
        private bool success = true;
        private Acc accountID = new Acc();

        public static void Main(string[] args)
        {
            Program pro = new Program();

            do

            {
                pro.login();
            } while (!pro.check());
            while (true)
            {
                string choice = pro.main();
                switch (choice)
                {
                    case "1":
                        pro.createAcc();

                        break;
                    case "2":

                        pro.search();
                        break;

                    case "3":
                        pro.deposit();
                        break;

                    case "4":
                        pro.withdraw();
                        break;

                    case "5":
                        pro.statement();
                        break;

                    case "6":
                        pro.deleteAcc(); ;
                        break;

                    case "7": break;

                }
            }
        }
        public void login()
        {
            Console.WriteLine("\t\t   ===================================");
            Console.WriteLine("\t\t  l  \t\t\t\t      l");
            Console.WriteLine("\t\t ㅣ Welcome to Simple Banking  System l");
            Console.WriteLine("\t\t ㅣ \t\t\t\t      l");
            Console.WriteLine("\t\t ㅣ===================================l");
            Console.WriteLine("\t\t ㅣ \t   LOGIN TO START\t      l");
            Console.WriteLine("\t\t ㅣ \t\t\t\t      l");

            Console.Write("\t\t  l     User name: ");
            int cursorPosUserNameLeft = Console.CursorLeft;
            int cursorPosUserNameTop = Console.CursorTop;
            string name = "";
            Console.Write("\t\t      l ");
            Console.Write("\n\t\t  l     Password: ");

            int CursorPosPwdLeft = Console.CursorLeft;
            int CursorPosPwdTop = Console.CursorTop;
            string password = "";
            Console.Write("\t\t      l ");
            Console.WriteLine();
            Console.WriteLine("\t          l \t\t\t\t      l");

            Console.WriteLine("\t\t   ===================================");


            Console.SetCursorPosition(cursorPosUserNameLeft, cursorPosUserNameTop);

            System.IO.Stream s = System.Console.OpenStandardInput();
            System.IO.StreamReader st = new System.IO.StreamReader(s);
            int tmp = st.Read();

            while (tmp != '\r')
            {
                name += Convert.ToChar(tmp);
                tmp = st.Read();
            }
            this.name = name;
            st.Close();
            Console.SetCursorPosition(CursorPosPwdLeft, CursorPosPwdTop);

            while (true)
            {
                ConsoleKeyInfo csk = Console.ReadKey(true);

                if (csk.Key != ConsoleKey.Enter)
                {
                    if (csk.Key != ConsoleKey.Backspace)
                    {
                        password += csk.KeyChar.ToString();
                        Console.Write("*");
                    }

                    else
                    {
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    Console.WriteLine();

                    break;
                }
            }

            this.password = password;
        }
        public bool check()
        {
            Console.Clear();
            StreamReader str = new StreamReader("login.txt");
            string content = str.ReadLine();
            while (content != null)
            {
                string[] up = content.Split(' ');
                if (up.Length == 2)
                {
                    if (up[0] == name && up[1] == password)
                        return true;
                }
                content = str.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("\t\t       ---   ERROR   ---");
            Console.WriteLine("\t\t\t Please try again!");

            return false;
        }
        public string main()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("\t\t ===================================");
            Console.WriteLine("\t\tl   Welcome to My Banking System    l");
            Console.WriteLine("\t\tl===================================l");
            System.Console.WriteLine("\t\tl  1. Create a new account    \t    l");
            System.Console.WriteLine("\t\tl  2. Search for an account    \t    l");
            System.Console.WriteLine("\t\tl  3. Deposit  \t\t\t    l");
            System.Console.WriteLine("\t\tl  4. Withdraw  \t\t    l");
            System.Console.WriteLine("\t\tl  5. A/C statement   \t\t    l");
            System.Console.WriteLine("\t\tl  6. Delete account  \t\t    l");
            System.Console.WriteLine("\t\tl  7. Exit   \t\t\t    l");
            Console.WriteLine("\t\t=====================================");
            System.Console.Write("\t\t Enter your choice (1-7): ");


            int cursorPosChoiceLeft = Console.CursorLeft;

            int cursorPosChoiceTop = Console.CursorTop;
            Console.SetCursorPosition(cursorPosChoiceLeft, cursorPosChoiceTop);

            System.IO.Stream s = System.Console.OpenStandardInput();
            System.IO.StreamReader rd = new System.IO.StreamReader(s);

            string choice = "";
            int tmp = rd.Read();



            while (tmp != '\r')

            {
                choice += Convert.ToChar(tmp);
                tmp = rd.Read();

            }
            return choice;


        }


        public void createAcc()
        {
            Console.Clear();
            accountID.init();
            Account acc = new Account();
            acc.accountID = accountID.get_id();
            acc.input_account();
            Console.WriteLine("========================================================================");
            Console.WriteLine("========================================================================");

            Console.Write("\n\n\t     Is the information correct? (y/n)?");
            int cursorPosChoiceLeft = Console.CursorLeft;
            int cursorPosChoiceTop = Console.CursorTop;
            string choice = Console.ReadLine().ToLower();
            Console.SetCursorPosition(cursorPosChoiceLeft, cursorPosChoiceTop);
            if (choice == "y")
            {
                
                Console.WriteLine("\n\t\t\t == Created successfully! == ");
                Console.WriteLine("\n\t\t\t == Detailed will provied by email. == ");
                Thread.Sleep(3000);
                acc.write();
            }
            else
            {

                this.createAcc();
            }


        }
       

          public void search()
        {

            Console.Clear();
            accountID.init();
            while (true)
            {
                Console.WriteLine("\t\t =======================================");
                Console.WriteLine("\t\t l \t     SEARCH AN ACCOUNT\t\tl ");
                Console.WriteLine("\t\t =======================================");
                Console.WriteLine("\t\t l \t     Enter The Details \t\tl ");
                Console.WriteLine("\t\t =======================================");

                Console.Write("\n\t\t\t  Account Number: ");


                if (!success)
                {
                    int cursorPosAccountLeft = Console.CursorLeft;
                    int cursorPosAccountTop = Console.CursorTop;
                    Console.WriteLine("\n\t\t\t   Please enter only numbers!");
                    Console.SetCursorPosition(cursorPosAccountLeft, cursorPosAccountTop);
                }
                string rl = Console.ReadLine();
                try
                {

                    int ti = Convert.ToInt32(rl, 10);

                    Console.WriteLine("\t\t =======================================");
                    if (accountID.m_id_file.ContainsKey(ti))
                    {
                        Account acc = new Account();
                        acc.read(rl);
                        acc.output();
                        Console.WriteLine("\t\t=====================================");
                        Console.Write("\t\t Check another account (y/n)?: ");
                        string input = Console.ReadLine().ToLower();
                        Console.Clear();
                        if (input == "y")
                        {
                            this.search();
                        }
                        else if (input == "n")
                        {
                            break;
                        }
                        else if (input != "y" || input != "n")
                        {

                            
                            Console.WriteLine(" Only y or n input is available ");

                            Thread.Sleep(300);

                            this.search();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t    Account not found!");
                        Console.Write("\t\t Check another account (y/n)?: ");
                        string input = Console.ReadLine().ToLower();
                        if (input == "y")
                        {
                            this.search();
                        }
                        else if (input == "n")
                        {
                            break;
                        }
                        else if (input != "y" || input != "n")
                        {
                            Console.WriteLine(" Only y or n input is available ");
                            this.search();
                        }
                    }

                }
                catch (Exception)
                {
                    Console.Clear();
                    success = false;
                    if (success)
                    {
                        this.search();
                        Console.Clear();
                    }
                }
            }
        }
     
        public void deposit()
        {
            Console.Clear();
            accountID.init();
            while (true)
            {
                // string ids = InputSameLine.input("Account Number: ");
                Console.WriteLine("\t\t  =======================================");
                Console.WriteLine("\t\t | \t\t  DEPOSIT \t\t | ");
                Console.WriteLine("\t\t  =======================================");
                Console.WriteLine("\t\t | \t    ENTER THE DETAILS \t\t | ");
                Console.WriteLine("\t\t  =======================================");
                Console.Write("\n\t\t\t  Account Number: ");


                if (!success)
                {
                    int cursorPosAccountLeft = Console.CursorLeft;
                    int cursorPosAccountTop = Console.CursorTop;
                    Console.WriteLine("\n\t\t\t  Please enter only numbers!");
                    Console.SetCursorPosition(cursorPosAccountLeft, cursorPosAccountTop);
                }

               
                string ids = Console.ReadLine();
                try
                {

                    int idi = Convert.ToInt32(ids, 10);
                    if (accountID.m_id_file.ContainsKey(idi))
                    {
                        Console.WriteLine("\n\t\t     Account found! Enter the amount...");
                        Console.Write("\t\t     Amount: $");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        Account acc = new Account();
                        acc.read(ids);
                        if (amount > 0)
                        {
                            acc.balance += amount;
                            acc.statement.Add(amount.ToString());
                            Console.WriteLine("\t\t\t ---Deposit successfull!--- ");
                            acc.write();
                        }
                            else
                        {
                             Console.WriteLine("\t\t\t Positive Number Only!");
                        }

                         Console.Write("\t\t Check another account (y/n)?: ");
                         string input = Console.ReadLine().ToLower();
                         if (input == "y")
                        {
                            this.deposit();
                            break;
                        }
                           else if (input == "n")
                        {

                            break;

                        }
                           else if (input != "y" || input != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.deposit();

                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t    Account not found!");
                        Console.Write("\t\t\t\tRetry(y/n)?: ");
                        string input = Console.ReadLine().ToLower();
                        if (input == "y")
                        {
                            this.deposit();
                            break;
                        }
                        else if (input == "n")
                        {

                            break;

                        }
                        else if (input != "y" || input != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.deposit();

                        }
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    success = false;
                    if (success)
                    {
                        this.deposit();
                    }

                }

            }
        }

        public void withdraw()
        {
            Console.Clear();
            accountID.init();
            while (true)
            {
                Console.WriteLine("\t\t  =======================================");
                Console.WriteLine("\t\t | \t\t  WITHDRAW \t\t | ");
                Console.WriteLine("\t\t  =======================================");
                Console.WriteLine("\t\t | \t    Enter The Details \t\t | ");
                Console.WriteLine("\t\t  =======================================");
                Console.Write("\n\t\t\t  Account Number: ");

                if (!success)
                {
                    int cursorPosAccountLeft = Console.CursorLeft;
                    int cursorPosAccountTop = Console.CursorTop;
                    Console.WriteLine("\n\t\t\t  Please enter only numbers!");
                    Console.SetCursorPosition(cursorPosAccountLeft, cursorPosAccountTop);
                }

                try
                {
                    string ids = Console.ReadLine();
                    int idi = Convert.ToInt32(ids, 10);
                    if (accountID.m_id_file.ContainsKey(idi))
                    {
                        Console.WriteLine("\n\t\t     Account found! Enter the amount...");
                        Console.Write("\t\t\t      Amount: $");

                        int amount = Convert.ToInt32(Console.ReadLine());
                        Account acc = new Account();
                        acc.read(ids);
                        if (acc.balance >= amount)
                        {
                            acc.balance -= amount;
                            acc.statement.Add(amount.ToString());
                            Console.WriteLine("\t\t\t ---Withdraw successfull!--- ");
                            acc.write();
                        }
                        else
                        {
                            Console.WriteLine("\t\t\t - Insufficient funds in the account. - ");
                        }

                        Console.Write("\t\t Check another account(y/n) ?: ");
                        string input = Console.ReadLine().ToLower();
                        if (input == "y")
                        {
                            this.withdraw();
                            break;
                        }
                        else if (input == "n")
                        {

                            break;

                        }
                        else if (input != "y" || input != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.withdraw();

                        }

                    }

                    else
                    {
                        Console.WriteLine("\t\t\t    Account not found!");
                        Console.Write("\t\t\t\tRetry(y/n)?: ");
                        string input = Console.ReadLine().ToLower();
                        if (input == "y")
                        {
                            this.withdraw();
                            break;
                        }
                        else if (input == "n")
                        {
                            break;
                        }
                        else if (input != "y" || input != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.withdraw();

                        }

                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    success = false;
                    if (success)
                    {
                        this.withdraw();
                    }

                }
            }
        }

        public void statement()
        {
            Console.Clear();
            accountID.init();
            while (true)
            {
                Console.WriteLine("\t\t  ---------------------------------------");
                Console.WriteLine("\t\t | \t\t  STATEMENT \t\t | ");
                Console.WriteLine("\t\t  ---------------------------------------");
                Console.WriteLine("\t\t | \t    Enter The Details \t\t | ");
                Console.WriteLine("\t\t  ---------------------------------------");
                Console.Write("\n\t\t\t  Account Number: ");

                if (!success)
                {
                    int cursorPosAccountLeft = Console.CursorLeft;
                    int cursorPosAccountTop = Console.CursorTop;
                    Console.WriteLine("\n\t\t\t   Please enter only numbers! ");
                    Console.SetCursorPosition(cursorPosAccountLeft, cursorPosAccountTop);
                }

                try
                {
                    string ids = Console.ReadLine();
                    int idi = Convert.ToInt32(ids, 10);
                    if (accountID.m_id_file.ContainsKey(idi))
                    {
                        Console.WriteLine("\n\t   Account found! The statement is  displayed below...");
                        Account acc = new Account();
                        acc.read(ids);
                        acc.output_statement();
                        Console.Write("\t\t\t Email statement (y/n)?: ");
                        string input = Console.ReadLine();
                        if (input == "y")
                        {
                            accountID.del(ids);
                            Console.WriteLine("\t\t\t Email sent successfully!...");
                        }

                        Console.Write("\t\t Check another account (y/n)?: ");
                        string choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            this.statement();
                            break;
                        }
                        else if (choice == "n")
                        {
                            break;
                        }
                        else if (choice != "y" || choice != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.statement();

                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t    Account not found!");
                        Console.Write("\t\t\t      Retry(y/n)?: ");
                        string input = Console.ReadLine().ToLower();
                        if (input == "y")
                        {
                            this.statement();
                            break;
                        }
                        else if (input == "n")
                        {
                            break;
                        }
                        else if (input != "y" || input != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.statement();

                        }
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    success = false;
                    if (success)
                    {
                        this.statement();
                    }
                }
            }
        }

        public void deleteAcc()
        {
            Console.Clear();
            accountID.init();
            while (true)
            {
                Console.WriteLine("\t\t  ---------------------------------------");
                Console.WriteLine("\t\t | \t     DELETE AN ACCOUNT \t         | ");
                Console.WriteLine("\t\t  ---------------------------------------");
                Console.WriteLine("\t\t | \t     Enter The Details \t\t | ");
                Console.WriteLine("\t\t  ---------------------------------------");
                Console.Write("\n\t\t\t  Account Number: ");


                if (!success)
                {
                    int cursorPosAccountLeft = Console.CursorLeft;
                    int cursorPosAccountTop = Console.CursorTop;
                    Console.WriteLine("\n\t\t\t  Please enter only numbers!");
                    Console.SetCursorPosition(cursorPosAccountLeft, cursorPosAccountTop);
                }

                try
                {
                    string ids = Console.ReadLine();
                    int idi = Convert.ToInt32(ids, 10);
                    if (accountID.m_id_file.ContainsKey(idi))
                    {
                        Console.WriteLine("\n\t\t  Account found! Details displayed below...");
                        Console.WriteLine("\t\t-----------------------------------------");
                        Account acc = new Account();
                        acc.read(ids);
                        acc.output();
                        Console.WriteLine("\t\t  ----------------------------------------");
                        Console.Write("\t\t\t      Delete (y/n)?: ");
                        string input = Console.ReadLine().ToLower();
                        if (input == "y")
                        {
                            accountID.del(ids);
                            Console.WriteLine("\t\t\t     Account Deleted!...");
                        }
                        else if (input == "n")
                        {
                            break;
                        }
                        else if (input != "y" || input != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.statement();

                        }
                        Console.Write("\t\t Check another account (y/n)?: ");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "y")
                        {
                            this.deleteAcc();
                            break;
                        }
                        else if (choice == "n")
                        {
                            break;
                        }
                        else if (choice != "y" || choice != "n")
                        {
                            Console.WriteLine("\t\t\t --- Only y or n input is available --- ");
                            this.deleteAcc();

                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t    Account not found!");
                        Console.Write("\t\t\t      Retry(y/n)?: ");
                        string yn = Console.ReadLine().ToLower();
                        if (yn == "y")
                        {
                            this.deleteAcc();
                        }
                        else
                        {
                            break;
                        }
                        Console.Write("\t\t Check another account (y/n)?: ");
                        string input = Console.ReadLine().ToLower();
                        if (input == "y")
                        {
                            Console.Clear();
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    success = false;
                    if (success)
                    {
                        this.deleteAcc();
                    }
                }
            }
        }


    }
}
