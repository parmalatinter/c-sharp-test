using ConsoleAppTest.pg.model;

namespace ConsoleAppTest
{
    /// <summary>
    /// Entity Frameworkを使ってPostgreSQLにアクセスする方法
    /// https://www.fenet.jp/dotnet/column/%E8%A8%80%E8%AA%9E%E3%83%BB%E7%92%B0%E5%A2%83/542/
    /// </summary>
    public class Sql
    {
        public const string res = "Hello World!";

        public static void GetMovie()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            var test = applicationDbContext.Movie;

        }

        public string ByeBye()
        {
            return res;
        }
    }
}
