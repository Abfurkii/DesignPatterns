using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ali = new Employee { Name = "Ali İhsan Yıldırım" };
            Employee apo = new Employee { Name = "Abdullah Furkan Barış" };
            Employee ilker = new Employee { Name = "İlker Kılıç" };

            Employee ilayda = new Employee { Name = "İlayda" };

            Employee employe1 = new Employee { Name = "John" };
            Employee employe2 = new Employee { Name = "Jack" };

            ali.PersonAdd(apo);
            ali.PersonAdd(ilker);
            ali.PersonAdd(ilayda);

            apo.PersonAdd(employe1);
            ilayda.PersonAdd(employe2);

            Console.WriteLine(ali.Name);
            foreach (Employee employe in ali)
            {
                Console.WriteLine("  {0}",employe.Name);
                foreach (var person in employe)
                {
                    Console.WriteLine("    {0}", person.Name);
                }
            }

            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _persons = new List<IPerson>();
        public string Name { get; set; }
        public void PersonAdd(IPerson person)
        {
            _persons.Add(person);
        }
        public void PersonRemove(IPerson person)
        {
            _persons.Remove(person);
        }
        public IPerson GetPerson(int index)
        {
            return _persons[index];
        }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var person in _persons)
            {
                yield return person;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
