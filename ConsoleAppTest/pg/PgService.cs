using ConsoleAppTest.pg.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleAppTest.pg
{
    /// <summary>
    /// Entity Frameworkを使ってPostgreSQLにアクセスする方法
    /// https://www.fenet.jp/dotnet/column/%E8%A8%80%E8%AA%9E%E3%83%BB%E7%92%B0%E5%A2%83/542/
    /// </summary>
    public class PgService
    {

        public static string GetMovie()
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            // [出力]
            foreach (var member in context.Movie)
            {
                return $"{member.Id}, {member.Name}";
            }

            return "Null";
        }
    }
}
