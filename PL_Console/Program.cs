using System;
using System.Text;
using System.Security;
using CTS_BL;
using System.Text.RegularExpressions;
namespace CTS_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuChoice();
        }
        private static void MenuChoice()
        {
            Console.Clear();
            string[] choice = { "dang nhap", "Thoat chuong trinh" };
            int choose = Menu("chao mung ban", choice);
            switch (choose)
            {
                case 1:
                    MenuLogin();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        private static void MenuLogin()
        {
            Console.Clear();
            string row1 = "========================================";
            string row2 = "----------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine(" ĐĂNG NHẬP");
            Console.WriteLine(row2);
            Console.Write("Nhập Username: ");
            string un = Console.ReadLine();
            Console.Write("Nhập Password: ");
            string pw = Password();
            char choice;
            while ((validate(un, 0) == false) || (validate(pw, 0) == false))
            {
                Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                try
                {
                    choice = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    continue;
                }
                switch (choice)
                {
                    case 'Y':
                        break;
                    case 'y':
                        break;
                    case 'n':
                        MenuChoice();
                        break;
                    case 'N':
                        MenuChoice();
                        break;
                    default:
                        continue;
                        // break;
                }
                Console.Clear();
                    Console.WriteLine("Username và Password không được chứa ký tự đặc biệt! ");
                    Console.WriteLine(row1);
                    Console.WriteLine(" ĐĂNG NHẬP");
                    Console.WriteLine(row2);
                    Console.Write("Nhập lại Username: ");
                    un = Console.ReadLine();
                    Console.Write("Nhập lại Password: ");
                    pw = Password();
            }
        }
    }
}
            