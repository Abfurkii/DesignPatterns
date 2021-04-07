using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObsserver());
            productManager.UpdateProduct();

            Console.ReadLine();
        }
    }
    public class ProductManager
    {
        List<ObserverBase> _observers = new List<ObserverBase>();
        public void UpdateProduct()
        {
            Console.WriteLine("Product price changed!");
            Notify();
        }
        public void Attach(ObserverBase observerBase)
        {
            _observers.Add(observerBase);
        }
        public void Detach(ObserverBase observerBase)
        {
            _observers.Remove(observerBase);
        }
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Message();
            }
        }
    }
    public abstract class ObserverBase
    {
        public abstract void Message();
    }
    public class CustomerObserver : ObserverBase
    {
        public override void Message()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }
    }
    public class EmployeeObsserver : ObserverBase
    {
        public override void Message()
        {
            Console.WriteLine("Message to employee : Product price changed!");
        }
    }
}
