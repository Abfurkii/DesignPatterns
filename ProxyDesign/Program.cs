using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase work = new ProxyControl();
            Console.WriteLine(work.Calculate());
            Console.WriteLine(work.Calculate());


            Console.ReadLine();
        }
    }
    public abstract class CreditBase
    {
        public abstract int Calculate();
    }

    public class DoYourWork : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i <= 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    public class ProxyControl : CreditBase
    {
        private int _result;
        private DoYourWork _work;
        public override int Calculate()
        {
            if (_work == null)
            {
                _work = new DoYourWork();
                _result = _work.Calculate();
            }
            return _result;
        }
    }
}

