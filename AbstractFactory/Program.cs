using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.Add();

            Console.ReadLine();
        }
    }
    #region Logging
    public abstract class Logging
    {
        public abstract void Log();
    }
    public class Log4NetLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger!");
        }
    }
    public class NLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged with NLogger!");
        }
    }
    #endregion
    #region Caching
    public abstract class Caching
    {
        public abstract void Cache();
    }
    public class MemCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with memCache!");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with RedisCache!");
        }
    }
    #endregion
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging GetLogging();
        public abstract Caching GetCaching();
    }
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Logging GetLogging()
        {
            return new Log4NetLogger();
        }
        public override Caching GetCaching()
        {
            return new MemCache();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Logging GetLogging()
        {
            return new NLogger();
        }
        public override Caching GetCaching()
        {
            return new MemCache();
        }
    }
    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;

        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.GetLogging();
            _caching = _crossCuttingConcernsFactory.GetCaching();
        }
        public void Add()
        {
            Console.WriteLine("Added!");
            _logging.Log();
            _caching.Cache();
        }
    }
}
