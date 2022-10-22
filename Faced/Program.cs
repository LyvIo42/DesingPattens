using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faced
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }

    public class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    interface ICaching
    {
        void Cache();
    }
    public class Autorize:IAutorize
    {
        public void CheckUSer()
        {
            Console.WriteLine("User checked");
        }
    }

    interface IAutorize
    {
        void CheckUSer();
    }
    class Validation:IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }

    class CustomerManager
    {
        private CrossCuttongConcernsFacede _concers;
        public CustomerManager()
        {
            _concers = new CrossCuttongConcernsFacede();
        }
        public void Save()
        {
            _concers.Autorize.CheckUSer();
            _concers.Caching.Cache();
            _concers.Logging.Log();
            _concers.Validation.Validate();
            Console.WriteLine("Saved");
        }

    }
    class CrossCuttongConcernsFacede
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAutorize Autorize;
        public IValidate Validation;
        public CrossCuttongConcernsFacede()
        {
            Logging = new Logging();
            Caching = new Caching();
            Autorize = new Autorize();
            Validation = new Validation();
        }
    }
}
