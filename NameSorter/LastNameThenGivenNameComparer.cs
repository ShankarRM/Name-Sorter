using System.Collections.Generic;

namespace NameSorter
{
    public class LastNameThenGivenNameComparer : Comparer<Person>
    {
        public override int Compare(Person x, Person y)
        {
            int result = x.LastName.CompareTo(y.LastName);
            return result != 0 ? result : x.GivenName.CompareTo(y.GivenName);
        }
    }
}
