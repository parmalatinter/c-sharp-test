using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppTest;
using ConsoleAppTest.pg;
using Microsoft.QualityTools.Testing.Fakes;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// �ʏ�e�X�g
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            string actual = Program.Hello();
            Assert.AreEqual(Program.res, actual);
        }

        /// <summary>
        /// Shim�ŏ㏑��
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
        /// Shim�ŏ㏑���������ƂɌ��̃��\�b�h���Ăяo��
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            using (ShimsContext.Create())
            {
                ConsoleAppTest.Fakes.ShimProgram.Hello = () =>
                {
                    return ShimsContext.ExecuteWithoutShims (() => {
                        return Program.Hello();
                    });
                };
                string actual = Program.Hello();
                Assert.AreEqual(Program.res, actual);
            }
        }

        /// <summary>
        /// Shim�ŏ㏑���������ƂɌ��̃��\�b�h���Ăяo��
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            using (ShimsContext.Create())
            {
                ApplicationDbContext applicationDbContext = new ApplicationDbContext();
                //var actual = from line in applicationDbContext.Movies select line;
                //Assert.AreEqual(Program.res, actual);

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    // [�o��]
                    foreach (var member in db.Movie)
                    {
                        Console.WriteLine($"{member.Id}, {member.Name}");
                        Assert.AreEqual(1, member.Id);
                        Assert.AreEqual("TEST", member.Name);
                    }
                }
            }
        }
    }
}
