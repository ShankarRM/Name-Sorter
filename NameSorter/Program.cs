using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {


            IConfiguration Configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            string sortedFileName = Configuration.GetValue<string>("sortedfile");
            string unsortedFile = Configuration.GetValue<string>("unsortedfile");
            string nameSeprator = Configuration.GetValue<string>("nameSeprator");

            var names = Helper.ReadAllText(unsortedFile);
            Console.WriteLine(names);
            var person = new Person();
            if (names!=null)
            {
                person.Add(names, nameSeprator);
                person.Sort(new LastNameThenGivenNameComparer());
                person.Print();
                person.WriteToFile(sortedFileName);
            }
            else
            {
                Console.WriteLine($"Unable to process file {unsortedFile}");
            }
            
            
            
        }
    }
}
