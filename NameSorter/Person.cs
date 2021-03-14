using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter
{
    public class Person
    {

        private List<Person> personCollection { get; set; }
        public IEnumerable<Person> Persons { get { return this.personCollection; } }
        private string _fullName;
        private string _nameSeprator;

        public string NameSeprator
        {
            get { return _nameSeprator; }
            set { _nameSeprator = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            private set { _fullName = value; }
        }

        public string GivenName
        {
            get
            {
                if (this.FullName != null)
                {
                    return string.Join(" ", this.FullName.Split(this.NameSeprator).SkipLast(1).Select(name => name));
                }
                return string.Empty;
            }
        }
        public string LastName
        {
            get
            {
                if (this.FullName != null)
                {
                    return this.FullName.Split(this.NameSeprator).Last();
                }
                return string.Empty;
            }
        }

        public Person()
        {
            personCollection = new List<Person>();
        }
        public Person(string fullName, string nameSeprator)
        {
            this._fullName = fullName;
            this._nameSeprator = nameSeprator;
        }
        public void Add(string fullName, string nameSeprator)
        {
            var person = new Person(fullName, nameSeprator);

            this.personCollection.Add(person);
        }
        public void Add(string[] names, string nameSeprator)
        {
            
            foreach (var name in names)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    Add(name, nameSeprator);
                }

            }


        }

        public void Sort(Comparer<Person> comparable)
        {
            this.personCollection.Sort(comparable);
        }
        public void Print()
        {
            foreach (var person in this.personCollection)
            {
                Console.WriteLine($"{person.GivenName} {person.LastName}");
            }
        }
        public void WriteToFile(string fileName)
        {
            Console.WriteLine("Writing sorted file .....");
            File.WriteAllText(fileName, string.Empty);
            foreach (var item in this.personCollection)
            {
                File.AppendAllText(fileName, $"{item.GivenName} {item.LastName}{Environment.NewLine}");
            }
            Console.WriteLine($"Sorted file created at:{Path.GetFullPath(fileName)}");
        }


    }


}