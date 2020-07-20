using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1.Tests
{
    [TestClass]
    public class Tests
    {
        //Эти же функции нужно переписать с помощью Assert.That()

        [TestMethod]
        public void Test_001() //AreEqual/AreNotEqual
        {
            Assert.AreEqual(5,5);
            Assert.AreNotEqual(5,10);
        }
        [TestMethod]
        public void Test_002() //Contains
        {
            object[] objs = new object[0];
            StringAssert.Contains("qwerty", "qw");
            StringAssert.Contains("qwerty", "ty");
        }
        [TestMethod]
        public void Test_003() //True/False
        {
            Assert.IsTrue(10==10);
            Assert.IsFalse(5==10);
        }
        [TestMethod]
        public void Test_004() //IsEmpty/IsNotEmpty
        {

        }
        [TestMethod]
        public void Test_005() //IsInstanceOf
        {
            Assert.IsInstanceOfType("", typeof(string));
            Assert.IsInstanceOfType(1, typeof(int));
            Assert.IsInstanceOfType(1.0D, typeof(double));
            Assert.IsInstanceOfType(3_000.5F, typeof(float));
            Assert.IsInstanceOfType(1.0m, typeof(decimal));
        }
        [TestMethod]
        public void Test_006() //AreSame
        {
            object a = new object();
            object b = new object();

            Assert.AreSame(a,b);
        }
        [TestMethod]
        public void Test_007() //Greater/Less
        {

        }
        [TestMethod]
        public void Test_008() //Null/NotNull
        {
            string a = null;
            object b = 10;

            Assert.IsNull(a);
            Assert.IsNotNull(b);
        }
    }
}
