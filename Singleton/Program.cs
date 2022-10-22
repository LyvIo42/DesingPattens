using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save(); 
        }
    }
    class CustomerManager
    {
        static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            return _customerManager;
            
            //bu şekildede yazılabilir
            //customer menager null değerine bak eğer null degilse Customer manageri döndür
            //eğer nullsa CustomerManager newle anlamına gelir
            //return _customerManager ?? (_customerManager = new CustomerManager());
            //böylede yazılabilir
            //if (_customerManager == null)
            //{
            //    _customerManager = new CustomerManager();
            //}
            //return _customerManager;
        }
        public void Save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}
