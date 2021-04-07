using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }
    interface ILogging
    {
        void Log();
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }
    interface ICaching
    {
        void Cache();
    }
    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }
    interface IAutorize
    {
        void CheckUser();
    }
    class Autorize : IAutorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checkted!");
        }
    }
    class CustomerManager
    {
        CrossCuttingConcernsFacade ccc = new CrossCuttingConcernsFacade();
        public void Save()
        {
            ccc._logging.Log();
            ccc._caching.Cache();
            ccc._autorize.CheckUser();
            Console.WriteLine("Saved!");
        }
    }
    class CrossCuttingConcernsFacade
    {
        public ILogging _logging;
        public ICaching _caching;
        public IAutorize _autorize;
        public CrossCuttingConcernsFacade()
        {
            _logging = new Logging();
            _caching = new Caching();
            _autorize = new Autorize();
        }
    }
}
