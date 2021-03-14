using NUnit.Framework;
using System.IO;
using System.Linq;
namespace NameSorter.Test
{
    public class Tests
    {
        Person person = null;
        string nameseprator = " ";
        [SetUp]
        public void Setup()
        {
            person = new Person();
            
            person.Add("Adonis Julius Archer", nameseprator);
            person.Add("Marin Alvarez", nameseprator);
        }

        [Test]
        public void Given_FullName_Then_Calculate_LastName()
        {
            Assert.AreEqual(person.Persons.FirstOrDefault().LastName, "Archer");
        }
        [Test]
        public void Given_FullName_Then_Calculate_GivenName()
        {
            Assert.AreEqual(person.Persons.FirstOrDefault().GivenName, "Adonis Julius");
        }
        [Test]
        public void Should_Add_Names_With_LastName_GivenName()
        {
            Assert.AreEqual(person.Persons.Select(p => $"{p.GivenName} {p.LastName}"),  new string[] { "Adonis Julius Archer", "Marin Alvarez" });
        }
        [Test]
        public void Given_UnsortedList_Then_SortList_ByLastNameThenGivenName()
        {
            person.Sort(new LastNameThenGivenNameComparer());
            Assert.AreEqual(person.Persons.Select(p => $"{p.GivenName} {p.LastName}"), new string[] { "Marin Alvarez", "Adonis Julius Archer" });
        }
        [Test]
        public void Should_Throw_Exception_FileNotFound()
        {
            
            Assert.Throws<FileNotFoundException>(()=>Helper.ReadAllText("dfd"));
        }
    }
}