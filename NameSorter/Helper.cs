using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NameSorter
{
    public static class Helper
    {
        public static string[] ReadAllText(string fileName)
        {
            
            try
            {
                Console.WriteLine($"Reading from unsorted file:{fileName}");
                return File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException fileNotFoundException)
            {

                throw fileNotFoundException;
                
            }
            
            
            
        }
    }
}
