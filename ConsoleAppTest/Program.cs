using ConsoleAppTest.pg;
using System;

namespace ConsoleAppTest
{
    public class Program
    {
        public const string res1 = "Hello World!";
        public const string res2 = "Bye Bye";
        public const string errorMsg = "Please enter a numeric argument.";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(errorMsg);
                return;
            }
            bool test = int.TryParse(args[0], out int num);
            if (!test)
            {
                Console.WriteLine(errorMsg);
                return;
            }

            switch (num)
            {
                case 1:
                    Console.WriteLine(Hello());
                    break;
                case 2:
                    Console.WriteLine(ByeBye());
                    break;
                default:
                    Console.WriteLine(PgService.GetMovie());
                    break;
            }

        }

        public static string Hello()
        {
            return res1;
        }

        public static string ByeBye()
        {
            return res2;
        }
    }
}
