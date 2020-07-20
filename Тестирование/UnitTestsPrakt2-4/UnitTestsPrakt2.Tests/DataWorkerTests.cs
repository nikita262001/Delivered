using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestsPrakt2.Tests
{
    [TestFixture]
    public class DataWorkerTests
    {

        // ѕрактическа€ 4

        [Test]
        public void GetLastPerson_ListedNullPerson_ThrowsExeption()
        {
            List<Person> listP = null;
            Assert.That(() => DataWorker.GetLastPerson(listP), Throws.Exception);
        }

        [Test]
        public void GetLastPerson_ListedEmptyPerson_ThrowsExeption()
        {
            List<Person> listP = new List<Person> { };
            Assert.That(() => DataWorker.GetLastPerson(listP), Throws.Exception);
        }

        [Test]
        public void GetLastPerson_Listed3Person_ReturnsLastPerson()
        {
            Person p1 = new Person();
            Person p2 = new Person();
            Person p3 = new Person();
            List<Person> listP = new List<Person> { p1, p2, p3 };
            Assert.That(DataWorker.GetLastPerson(listP), Is.SameAs(p3));
        }

        [Test]
        public void GetLastPerson_Listed2Person_ReturnsFalse()
        {
            Person p1 = new Person();
            Person p2 = new Person();
            List<Person> listP = new List<Person> { p1, p2 };
            Assert.That(DataWorker.GetLastPerson(listP) == p1, Is.False);
        }

        // ѕрактическа€ 3

        [Test]
        public void GetAverageOfAge_Listed0Person_ReturnsExeption() // ¬ списке 0 человек (средний возраст нельз€ вычисл€ть из ничего, из-за этого должен быть Exception)
        {
            List<Person> listP = new List<Person> { };
            Assert.That(() => DataWorker.GetAverageOfAge(listP), Throws.Exception);
        }

        [Test]
        public void GetAverageOfAge_RegisteredPersonWithTheWrongAge_ReturnsExeption() // «арегистрированный человек с неправильным возрастом (отрицательного возраста не может быть)
        {
            List<Person> listP = new List<Person> { new Person { Age = 10 }, new Person { Age = -10 } };
            Assert.That(() => DataWorker.GetAverageOfAge(listP), Throws.Exception);
        }

        [Test]
        public void GetAverageOfAge_RegisteredPersonAgeIsTooBig_ReturnsExeption() // ¬озраст зарегистрированного лица слишком велик (слишком большое значение возраста)
        {
            List<Person> listP = new List<Person> { new Person { Age = 999999999 } };
            Assert.That(() => DataWorker.GetAverageOfAge(listP), Throws.Exception);
        }

        [Test]
        public void GetAverageOfAge_Listed3Person_Returns5() // ѕеречислено 3 человека (средний возраст 5)
        {
            List<Person> listP = new List<Person> { new Person { Age = 5 }, new Person { Age = 5 }, new Person { Age = 5 } };
            Assert.That(DataWorker.GetAverageOfAge(listP), Is.EqualTo(5));
        }

        [Test]
        public void GetAverageOfAge_Listed2Person_Returns0() // ѕеречислено 2 человека (средний возраст 0)
        {
            List<Person> listP = new List<Person> { new Person { Age = 0 }, new Person { Age = 0 } };
            Assert.That(DataWorker.GetAverageOfAge(listP), Is.EqualTo(0));
        }

        [Test]
        public void GetAverageOfAge_Listed2Person_Returns05() // ѕеречислено 2 человека (средний возраст 0.5)
        {
            List<Person> listP = new List<Person> { new Person { Age = 0 }, new Person { Age = 1 } };
            Assert.That(DataWorker.GetAverageOfAge(listP), Is.EqualTo(0.5));
        }

        [Test]
        public void GetAverageOfAge_Listed1Person_ReturnsAverageAge10() // ѕеречислено 1 человека (средний возраст 10)
        {
            List<Person> listP = new List<Person> { new Person { Age = 10 } };
            Assert.That(DataWorker.GetAverageOfAge(listP), Is.EqualTo(10));
        }

        // ѕрактическа€ 2

        Person pers;
        [SetUp]
        public void SetUp()
        {
            pers = new Person()
            {
                Name = "Nick",
                Age = 123
            };
        }

        [Test]
        public void GetFirstLetterFromName_FirstLetterFromNameIsNull_ThrowsException()
        {
            Person person = new Person() { };
            Assert.That(() => DataWorker.GetFirstLetterFromName(person), Throws.Exception);
        }

        [Test]
        public void GetFirstLetterFromName_FirstLetterFromNameSameAsSource_ReturnsTheSameLetter()
        {
            Assert.That(DataWorker.GetFirstLetterFromName(pers), Is.EqualTo('N'));
        }

        [TestCase('V')]
        [TestCase(' ')]
        public void GetFirstLetterFromName_FirstLetterFromNameNotSameAsSource_ReturnsTheNotSameLetter(char expected)
        {
            Assert.That(DataWorker.GetFirstLetterFromName(pers), Is.Not.EqualTo(expected));
        }

        [Test]
        public void IsPersonAdult_PersonDonNotHaveAge_ThrowsException()
        {
            Person person = new Person() { };
            Assert.That(() => DataWorker.IsPersonAdult(person), Throws.Exception);
        }

        [Test]
        public void IsPersonAdult_PersonAgeIsTooBig_ThrowsException()
        {
            Person person = new Person() { Age = 999999999 };
            Assert.That(() => DataWorker.IsPersonAdult(person), Throws.Exception);
        }

        [Test]
        public void IsPersonAdult_PersonAgeIsNegative_ThrowsException()
        {
            Person person = new Person() { Age = -20 };
            Assert.That(() => DataWorker.IsPersonAdult(person), Throws.Exception);
        }

        [Test]
        public void IsPersonAdult_PersonAfterTheAgeOf18_ReturnsTrue()
        {
            Assert.That(DataWorker.IsPersonAdult(pers), Is.True);
        }

        [Test]
        public void IsPersonAdult_PersonIs18YearsOld_ReturnsTrue()
        {
            Person person = new Person() { Age = 18 };
            Assert.That(DataWorker.IsPersonAdult(person), Is.True);
        }

        [Test]
        public void IsPersonAdult_PersonUnder18YearsOld_ReturnsFalse()
        {
            Person person = new Person() { Age = 5 };
            Assert.That(DataWorker.IsPersonAdult(person), Is.False);
        }
    }
}
/*[јтрибут]
public void (название метода)_(наша ситуаци€)_(то что мы думаем получить)
{  }*/
