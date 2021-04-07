using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kişiler
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            //Yetkiler
            manager.SetSuccesor(vicePresident);
            vicePresident.SetSuccesor(president);

            //Expense
            Expense expense = new Expense { Detail = "Detail", Amount = 790 };
            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }
    public class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
    public abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccesor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }
    public class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    public class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 500)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    public class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount>500)
            {
                Console.WriteLine("President handled the expense!");
            }
            else if (Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
}
