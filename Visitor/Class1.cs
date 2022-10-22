using System;
using System.Collections.Generic;

namespace Visitor
{
     class Program
    {
        static void Main(string[] args)
        {
            Manager Engin = new Manager { Name = "Engin", Salary = 1000 };
            Manager Salih = new Manager { Name = "Salih", Salary = 900 };

            Worker Derin = new Worker { Name = "Derin", Salary = 200 };
            Worker Ali = new Worker { Name = "Ali", Salary = 300 };
            Worker Semih = new Worker { Name = "Semih", Salary = 350 };

            Engin.Subordinates.Add(Derin);
            Salih.Subordinates.Add(Ali);
            Salih.Subordinates.Add(Semih);
            Salih.Subordinates.Add(Derin);

            Organistionalstruce organistionalstruce = new Organistionalstruce(Engin);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();
        }
      
    }
    class Organistionalstruce
    {
        public EmployeeBase Employee;

        public Organistionalstruce(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void visit(Worker worker);
        public abstract void visit(Manager manager);

    }
    class PayrollVisitor : VisitorBase
    {
        public override void visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1} ", worker.Name, worker.Salary);
        }

        public override void visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1} ", manager.Name, manager.Salary);
        }
    }
    class PayriseVisitor : VisitorBase
    {
        public override void visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}",worker.Name,worker.Salary*(decimal)1.1);
        }

        public override void visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }


}
