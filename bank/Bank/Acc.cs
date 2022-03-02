using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankApplication
{
    class Acc
    {
        public int m_id = 100000;
        public Dictionary<int, string> m_id_file = new Dictionary<int, string>();
        public string get_id()
        {
            string tmp = m_id.ToString();
            m_id++;
            return tmp;
        }
        public bool init()
        {
            m_id_file.Clear();
            string dirs = "account";
            string[] files = Directory.GetFiles(dirs, "*.txt");

            foreach (string path in files)
            {

                string pathtmp = path.Substring(8, path.Length - 12);
                int id = Convert.ToInt32(pathtmp, 10);
                m_id_file.Add(id, path);
                if (id >= m_id)
                {
                    m_id++;
                }
            }
            return true;
        }
        public void del(string id)
        {
            File.Delete("account/" + id + ".txt");
            init();
        }
    }

    class Account
    {
        public string firstName, lastName;
        public string address;
        public int phone;
        public string email;
        public string accountID;
        public int balance;
        public List<string> statement;

        public Account()
        {
            firstName = lastName = address = email = accountID = "";
            balance = phone = 0;
            statement = new List<string>();

        }
        public void input_account()
        {


            Console.WriteLine("\t\t ----------------------------------");
            Console.WriteLine("\t\t| \t  CREATE A NEW ACCOUNT \t   |");
            Console.WriteLine("\t\t ----------------------------------");
            Console.WriteLine("\t\t| \t   Enter the Details \t   |");
            Console.WriteLine("\t\t ----------------------------------");
            Console.Write("\t\t First Name: ");
            int cursorPosFNameLeft = Console.CursorLeft;
            int cursorPosFNameTop = Console.CursorTop;

            Console.Write("\n\t\t Last Name: ");
            int cursorPosLNameLeft = Console.CursorLeft;
            int cursorPosLNameTop = Console.CursorTop;

            Console.Write("\n\t\t Address: ");
            int cursorPosAddrLeft = Console.CursorLeft;
            int cursorPosAddrTop = Console.CursorTop;

            Console.Write("\n\t\t Phone: ");
            int cursorPosPhoneLeft = Console.CursorLeft;
            int cursorPosPhoneTop = Console.CursorTop;

            Console.Write("\n\t\t Email: ");
            int cursorPosEmailLeft = Console.CursorLeft;
            int cursorPosEmailTop = Console.CursorTop;

            Console.SetCursorPosition(cursorPosFNameLeft, cursorPosFNameTop);
            firstName = Console.ReadLine();
            Console.SetCursorPosition(cursorPosLNameLeft, cursorPosLNameTop);
            lastName = Console.ReadLine();
            Console.SetCursorPosition(cursorPosAddrLeft, cursorPosAddrTop);
            address = Console.ReadLine();

            while (firstName == "" || lastName == "" || address == "")
            {
                if (firstName == "")
                {
                    Console.WriteLine("\n\n\n\t\t First name can not be empty");
                    Console.SetCursorPosition(cursorPosFNameLeft, cursorPosFNameTop);
                    firstName = Console.ReadLine();
                }
                if (lastName == "")
                {
                    Console.WriteLine("\n\n\n\n\n\t\t Last name can not be empty!");
                    Console.SetCursorPosition(cursorPosLNameLeft, cursorPosLNameTop);
                    lastName = Console.ReadLine();
                }
                if (address == "")
                {
                    Console.WriteLine("\n\n\n\n\t\t Address can not be empty!");
                    Console.SetCursorPosition(cursorPosAddrLeft, cursorPosAddrTop);
                    address = Console.ReadLine();
                }
            }

            Console.SetCursorPosition(cursorPosPhoneLeft, cursorPosPhoneTop);
            string phoneInput = Console.ReadLine();

            try
            {


                phone = Convert.ToInt32(phoneInput);
                if (phoneInput.Length > 10)
                {
                    Console.WriteLine("\n\n\t Phone: Number only, should not be more than 10 characters");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("\n\n\tPhone: Number only, should not be more than 10 characters");
                Console.SetCursorPosition(cursorPosPhoneLeft, cursorPosPhoneTop);

                while (phoneInput.Length < 0 || phoneInput.Length > 10 || !int.TryParse(phoneInput, out phone))
                {
                    try
                    {
                        phoneInput = Console.ReadLine();
                        phone = Convert.ToInt32(phoneInput);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\n\n\t Phone: Number only, should not be more than 10 characters");
                        Console.SetCursorPosition(cursorPosPhoneLeft, cursorPosPhoneTop);
                        continue;
                    }
                }
            }

            Console.SetCursorPosition(cursorPosEmailLeft, cursorPosEmailTop);
            email = Console.ReadLine();

            while (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("\n\t---------------Unvalid Email!-----------------");
                Console.SetCursorPosition(cursorPosEmailLeft, cursorPosEmailTop);
                email = Console.ReadLine();
            }

            Console.WriteLine("\n\t~~~~~~~~~~~~~  Account number is: {0}  ~~~~~~~~~~~", accountID);

        }

        public void output()
        {
            Console.WriteLine("\t\t╔===================================╗");
            Console.WriteLine("\t\t  \t    Account Details  \t");
            Console.WriteLine("\t\t╚===================================╝");
            Console.WriteLine("\t\t  \t Account No: {0}", accountID);
            Console.WriteLine("\t\t  \t Account Balance: {0}", balance);
            Console.WriteLine("\t\t  \t First Name: {0}", firstName);
            Console.WriteLine("\t\t  \t Last Name: {0}", lastName);
            Console.WriteLine("\t\t  \t Address: {0}", address);
            Console.WriteLine("\t\t  \t Phone: {0}", phone);
            Console.WriteLine("\t\t  \t Email: {0}", email);
        }
        public void output_statement()
        {
            Console.WriteLine("\t\t  ---------------------------------------");
            Console.WriteLine("\t\t  \t Account No: {0}", accountID);
            Console.WriteLine("\t\t  \t Account Balance: {0}", balance);
            Console.WriteLine("\t\t  \t First Name: {0}", firstName);
            Console.WriteLine("\t\t  \t Last Name: {0}", lastName);
            Console.WriteLine("\t\t  \t Address: {0}", address);
            Console.WriteLine("\t\t  \t Phone: {0}", phone);
            Console.WriteLine("\t\t  \t Email: {0}", email);
            Console.WriteLine("\t\t  ---------------------------------------");
        }

        public void write()
        {
            string f = "account/" + accountID + ".txt";
            StreamWriter w = new StreamWriter(f);
            StringWriter ws = new StringWriter();
            ws.WriteLine("{0} {1} {2} {3} {4} {5}", firstName, lastName, address, phone, email, balance);
            w.WriteLine(ws.ToString());
            foreach (var s in statement)
            {
                w.WriteLine(s);
            }
            w.Close();
            Console.WriteLine("\t\t\t Account number is: {0}", accountID);
        }

        public void read(string id)
        {
            accountID = id;
            string f = "account\\" + accountID + ".txt";
            StreamReader r = new StreamReader(f);
            string s = r.ReadLine();
            string[] sar = s.Split(' ');
            if (sar.Length != 6)
            {
                r.Close();
                return;
            }
            firstName = sar[0];
            lastName = sar[1];
            address = sar[2];
            phone = Convert.ToInt32(sar[3], 10);
            email = sar[4];
            balance = Convert.ToInt32(sar[5], 10);
            while (true)
            {
                s = r.ReadLine();
                if (s == null)
                {
                    break;
                }
                if (s.Length != 0)
                {
                    statement.Add(s);
                }
            }
            r.Close();
        }

    }
}
