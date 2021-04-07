using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer person1 = new Customer { FirstName = "Abdullah", LastName = "Barış", Age = 22 };
            var person2 = (Customer)person1.Clone();
            person2.FirstName = "Ali";
            Console.WriteLine(person1.FirstName);
            Console.WriteLine(person2.FirstName);
            Console.WriteLine("Person1'in tipi : {0}",person1.GetType());
            Console.WriteLine("Person2'nin tipi : {0}", person2.GetType());

            Console.ReadLine();
        }
    }
    public abstract class Person
    {
        public abstract Person Clone();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int16 Age { get; set; }
    }
    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Student : Person
    {
        public string Departman { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
