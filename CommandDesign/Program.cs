using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController controller = new StockController();
            controller.TakeOrder(buyStock);
            controller.TakeOrder(sellStock);
            controller.PlaceOrder();

            Console.ReadLine();
        }
    }
    public class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock : {0}, {1} bought!", _name, _quantity);
        }
        public void Sell()
        {
            Console.WriteLine("Stock : {0}, {1} sold", _name, _quantity);
        }
    }
    public interface IOrder
    {
        void Execute();
    }
    public class BuyStock : IOrder
    {
        private StockManager _stockManager;
        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Buy();
        }
    }
    public class SellStock : IOrder
    {
        private StockManager _stockManager;
        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }
    public class StockController
    {
        List<IOrder> _orders = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }
        public void PlaceOrder()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}
