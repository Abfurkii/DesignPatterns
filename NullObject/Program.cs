using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(ForControlLogger.GetInstance());
            productManager.Save();
          
            Console.ReadLine();
        }
    }
    public class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            _logger.Log();
        }
    }
    public interface ILogger
    {
        void Log();
    }
    public class EfProductLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Ef");
        }
    }
    public class NhProductLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Nh"); 
        }
    }
    public class ForControlLogger : ILogger
    {
        private static object _lock = new object();
        private static ForControlLogger _logger;
        private ForControlLogger()
        {

        }
        public static ForControlLogger GetInstance()
        {
            lock (_lock)
            {
                if (_logger==null)
                {
                    _logger = new ForControlLogger();
                }
            }
            return _logger;
        }
        public void Log()
        {
            
        }
    }
    public class ProductManagerTest
    {
        public void MakeTest()
        {
            ProductManager productManager = new ProductManager(ForControlLogger.GetInstance());
        }
    }
}
