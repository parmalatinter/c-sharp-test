using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;
using ConsoleApp.pg.model;
using ConsoleApp.Migrations;
using ConsoleApp.http;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        /// �ʏ�e�X�g
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            string actual = Program.Hello();
            Assert.AreEqual(Program.res1, actual);
        }

        /// <summary>
        /// Shim�ŏ㏑��
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            using (ShimsContext.Create())
            {
                ConsoleApp.Fakes.ShimProgram.Hello = () =>
                {
                    return "TEST";
                };
                string actual = Program.Hello();
                Assert.AreEqual("TEST", actual);
            }
        }

        /// <summary>
        /// Shim�ŏ㏑���������ƂɌ��̃��\�b�h���Ăяo��
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            using (ShimsContext.Create())
            {
                ConsoleApp.Fakes.ShimProgram.Hello = () =>
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
        /// DB�擾�e�X�g
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                // [�o��]
                foreach (var member in context.Movie)
                {
                    Console.WriteLine($"{member.Id}, {member.Name}");
                    Assert.AreEqual(1, member.Id);
                    Assert.AreEqual("TEST", member.Name);
                }

                Console.WriteLine(context.Movie.Where(a => a.Name == "TEST").ToQueryString());
            }
        }

        /// <summary>
        /// Http(Ajax)���N�G�X�g�擾�e�X�g
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            Task.Run(async () =>
            {
                string res = await HttpService.HttpAjaxPostAsync();
                Assert.AreEqual("OK", res);
            }).GetAwaiter().GetResult();
  
        }
    }
}
