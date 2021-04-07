using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Add();

            Console.ReadLine();
        }
    }
    //Firma
    public interface ILoggerFactory
    {
        ILogger GetInstance();
    }
    //1. Fabrika
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger GetInstance()
        {
            return new AbLogger();
        }
    }
    //2. Fabrika
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger GetInstance()
        {
            return new AlLogger();
        }
    }
    //Base Ürün
    public interface ILogger
    {
        void Log();
    }
    //1. Ürün
    public class AbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with AbLogger!!");
        }
    }
    //2. Ürün
    public class AlLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with AlLogger!!");
        }
    }
    public class CustomerManager
    {
        private ILoggerFactory _loggerFacory;
        public CustomerManager(ILoggerFactory loggerFacory)
        {
            _loggerFacory = loggerFacory;
        }
        public void Add()
        {
            Console.WriteLine("Added!!");
            ILogger logger = _loggerFacory.GetInstance();
            logger.Log();
        }
    }
}
