using System;

namespace ConsoleAppTest
{
    public class Program
    {
        public const string res = "Hello World!";

        static void Main(string[] args)
        {
            string res = Hello();
            Console.WriteLine(res);
        }

        public static string Hello()
        {
            return res;
        }

        public string ByeBye()
        {
            return res;
        }
    }
}
