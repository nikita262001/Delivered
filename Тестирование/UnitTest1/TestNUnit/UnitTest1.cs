using NUnit.Framework;

namespace TestNUnit
{
    public class Tests
    {
        [SetUp] // ����� ����������� ����� �������� ������� ����� � ������� ���� �����
        public void Setup()
        {

        }

        [Test]
        public void Test_001() //AreEqual/AreNotEqual
        {
            Assert.AreEqual(5, 5);
            Assert.AreNotEqual(5, 10);
        }
        [Test]
        public void Test_001That() //AreEqual/AreNotEqual
        {
            Assert.That(5, Is.EqualTo(5));
            Assert.That(5, Is.Not.EqualTo(10));
        }
        [Test]
        public void Test_002() //Contains
        {
            StringAssert.Contains("qw", "qwerty");
            StringAssert.Contains("ty", "qwerty");

            StringAssert.Contains("y", "qwerty");
            StringAssert.Contains("", "qwerty");
        }
        [Test]
        public void Test_002That() //Contains
        {

            Assert.That("qwerty", Does.Contain("qw"));


        }

        [Test]
        public void Test_003() //True/False
        {
            Assert.IsTrue(10 == 10);
            Assert.IsFalse(5 == 10);
        }
        [Test]
        public void Test_003That() //True/False
        {
            Assert.That(10 == 10, Is.True);
            Assert.That(5 == 10, Is.False);
        }
        [Test]
        public void Test_004() //IsEmpty/IsNotEmpty
        {
            string a = " ";
            string c = string.Empty;
            string b = null;
            Assert.IsEmpty(a);
            Assert.IsEmpty(c);
            Assert.IsEmpty(b); // failed
        }
        [Test]
        public void Test_004That() //IsEmpty/IsNotEmpty
        {
            string a = "";
            string c = string.Empty;
            string b = null;
            Assert.That(a, Is.Empty);
            Assert.That(c, Is.Empty);
            Assert.That(b, Is.Empty);  // failed
        }
        [Test]
        public void Test_005() //IsInstanceOf
        {
            Assert.IsInstanceOf(typeof(int), 1);
            Assert.IsInstanceOf(typeof(double), 1.0D);
            Assert.IsInstanceOf(typeof(float), 3_000.5F);
            Assert.IsInstanceOf(typeof(decimal), 1.0m);
        }
        [Test]
        public void Test_005That() //IsInstanceOf
        {
            Assert.That(1, Is.TypeOf(typeof(int)));
            Assert.That(1.0, Is.TypeOf(typeof(double)));
            Assert.That(3_000.5F, Is.TypeOf(typeof(float)));
            Assert.That(1.0m, Is.TypeOf(typeof(decimal)));
        }
        [Test]
        public void Test_006()
        //AreSame ���������, ��� ��� �������� ����� � ��� �� ��������  - ���� ������ ��������� ���� � ��� �� ������ � ������.
        {
            object a = new object();
            object b = new object();
            string txt = "1";
            txt = "2";
            Assert.AreSame(10, 10); // false // � ������ ��������� ����� ������� � ������ �������� �� ���
            Assert.AreSame(txt, "2"); // true // ������ ������� � ������ "2" � ��������� �� ���� ,
                                      // ���� ������ ������� ���, �� ������� �����
            Assert.AreSame("", ""); // true // � ������ ��������� "" � ������� ��������� �� ���
            Assert.AreSame(a, b); // false // ������ ������ �� �������
        }
        [Test]
        public void Test_006That() //AreSame
        {
            object a = new object();
            object b = new object();

            Assert.That(Is.ReferenceEquals("", ""));
            Assert.That(Is.ReferenceEquals(a, b));  // failed
        }
        [Test]
        public void Test_007() //Greater/Less
        {
            Assert.Greater(11, 10); // >
            Assert.Less(5, 10); // <
        }
        [Test]
        public void Test_007That() //Greater/Less
        {
            Assert.That(11, Is.GreaterThan(10)); // >
            Assert.That(5, Is.LessThan(10)); // <
        }
        [Test]
        public void Test_008() //Null/NotNull
        {
            string a = null;
            object b = 10;
            string c = string.Empty;

            Assert.Null(a);
            Assert.NotNull(b);
            Assert.NotNull(c);
        }
        [Test]
        public void Test_008That() //Null/NotNull
        {
            string a = null;
            object b = 10;
            string c = string.Empty;

            Assert.That(a, Is.Null);
            Assert.That(b, Is.Not.Null);
            Assert.That(c, Is.Not.Null);
        }
    }
}