using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageBase = new EmailMessage();
            customerManager.Update();

            Console.ReadLine();
        }
    }
    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public abstract class MessageBase
    {
        public void Save()
        {
            Console.WriteLine("Saved!");
        }
        public abstract void Send(Body body);
    }
    public class SmsMessage : MessageBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} sent message by sms", body.Title);
        }
    }
    public class EmailMessage : MessageBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} sent message by email", body.Title);
        }
    }
    public class CustomerManager
    {
        public MessageBase MessageBase { get; set; }
        public void Update()
        {
            MessageBase.Send(new Body { Title = "Student exams add" });
            Console.WriteLine("Updated!");
        }
    }
}
