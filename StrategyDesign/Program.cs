using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculator = new After2010CreditCalculator();
            customerManager.Save();

            customerManager.CreditCalculator = new Before2010CreditCalculator();
            customerManager.Save();

            Console.ReadLine();
        }
    }
    public abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }
    public class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculeted using Before 2010");
        }
    }
    public class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculeted using After 2010");
        }
    }
    public class CustomerManager
    {
        public CreditCalculatorBase CreditCalculator { get; set; }
        public void Save()
        {
            Console.WriteLine("Saved!");
            CreditCalculator.Calculate();
        }
    }
}
