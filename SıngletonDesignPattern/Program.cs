using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SıngletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.GetInstance();
            customerManager.Add();

            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private static object _lockObject = new Object();
        private static CustomerManager _customerManager;
        private CustomerManager()
        {

        }
        public static CustomerManager GetInstance()
        {
            lock (_lockObject)
            {
                if (_customerManager==null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }
        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }
}
