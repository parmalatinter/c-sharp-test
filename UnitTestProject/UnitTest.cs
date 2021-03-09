using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppTest;
using ConsoleAppTest.pg.model;
using ConsoleAppTest.Migrations;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestCleanup]
        public void TestCleanup()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Truncate.Exec(context);
                Seed.Exec(context);
                Console.WriteLine("TestCleanup");
            }
        }

        /// <summary>
        /// 通常テスト
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            string actual = Program.Hello();
            Assert.AreEqual(Program.res1, actual);
        }

        /// <summary>
        /// Shimで上書き
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            using (ShimsContext.Create())
            {
                ConsoleAppTest.Fakes.ShimProgram.Hello = () =>
                {
                    return "TEST";
                };
                string actual = Program.Hello();
                Assert.AreEqual("TEST", actual);
            }
        }

        /// <summary>
        /// Shimで上書きしたあとに元のメソッドを呼び出す
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            using (ShimsContext.Create())
            {
                ConsoleAppTest.Fakes.ShimProgram.Hello = () =>
                {
                    return ShimsContext.ExecuteWithoutShims(() =>
                    {
                        Console.WriteLine("Overwride by shim");
                        return Program.Hello();
                    });
                };
                string actual = Program.Hello();
                Assert.AreEqual(Program.res1, actual);
            }
        }

        /// <summary>
        /// DB取得テスト
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                // [出力]
                foreach (var member in context.Movie)
                {
                    Console.WriteLine($"{member.Id}, {member.Name}");
                    Assert.AreEqual(1, member.Id);
                    Assert.AreEqual("TEST", member.Name);
                }

                Console.WriteLine(context.Movie.Where(a => a.Name == "TEST").ToQueryString());
            }
        }
    }
}
