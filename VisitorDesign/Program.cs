using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager apo = new Manager { Name = "Furkan", Salary = 1000 };
            Manager ali = new Manager { Name = "Ali", Salary = 1000 };
            Manager ilker = new Manager { Name = "İlker", Salary = 1000 };

            Worker john = new Worker { Name = "john", Salary = 900};
            Worker jack = new Worker { Name = "jack", Salary = 900 };
            Worker rock = new Worker { Name = "Rock", Salary = 800 };

            ali.Subordints.Add(john);
            ilker.Subordints.Add(jack);
            ilker.Subordints.Add(rock);

            OrganisationStructure organisationStructure = new OrganisationStructure(apo);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise = new Payrise();

            organisationStructure.GetAccept(payrollVisitor);
            organisationStructure.GetAccept(payrise);

            Console.ReadLine();
        }
    }
    public class OrganisationStructure
    {
        public EmployeeBase Employee;
        public OrganisationStructure(EmployeeBase employee)
        {
            Employee = employee;
        }
        public void GetAccept(VisitorBase visitorBase)
        {
            Employee.Accept(visitorBase);
        }
    }
    public abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitorBase);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    public class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordints = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordints { get; set; }
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
            foreach (var sub in Subordints)
            {
                sub.Accept(visitorBase);
            }
        }
        
    }
    public class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
        }
    }
    public abstract class VisitorBase
    {
        public abstract void Visit(Manager manager);
        public abstract void Visit(Worker worker);
    }
    public class PayrollVisitor : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Paid {1}", manager.Name, manager.Salary);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} Paid {1}", worker.Name, worker.Salary);
        }
    }
    public class Payrise : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.1);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.2);
        }
    }
}
