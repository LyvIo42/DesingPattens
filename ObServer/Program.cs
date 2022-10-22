using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerObServer = new CustomerObServer();
            ProductManger productManger = new ProductManger();
            productManger.Attach(customerObServer);
            productManger.Attach(new EmployeeObServer());
            productManger.Detach(customerObServer);
            productManger.UpdatePrice();
            Console.ReadLine();
        }
    }
    class ProductManger
    {
        List<ObServer> _obServers = new List<ObServer>();

        public void UpdatePrice()
        {
            Console.WriteLine("Product Price changed");
            Notify();
        }
        public void Attach(ObServer obServer)
        {
            _obServers.Add(obServer);
        }
        public void Detach(ObServer obServer)
        {
            _obServers.Remove(obServer);
        }
        private void Notify()
        {
            foreach (var observer in _obServers)
            {
                observer.Update();
            }
        }
    }
    abstract class ObServer
    {
        public abstract void Update();
    }
    class CustomerObServer : ObServer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer:Product price changed");
        }
    }
    class EmployeeObServer : ObServer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Employee:Product Price Changed");
        }
    }
}
