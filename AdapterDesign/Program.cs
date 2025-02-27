﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();

            Console.ReadLine();
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class AbLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged with AbLogger {0}", message);
        }
    }
    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("data info");
            Console.WriteLine("Saved!");
        }
    }
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged by Log4Net {0}",message);
        }
    }
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
