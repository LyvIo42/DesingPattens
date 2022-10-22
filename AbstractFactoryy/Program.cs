using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    //inherit olayı logginden implamente ediyoruz
    public class Log4Logged : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged With log4net");
        }
    }
    public class Nlogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged With nlogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string Data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string Data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCahce : Caching
    {
        public override void Cache(string Data)
        {
            Console.WriteLine("Cached with rediscahce");
        }
    }
    public abstract class CrossCuttinConcernsFactory
    {
        public abstract Logging CreatLogger();
        public abstract Caching CreateCahing();
    }
    public class Factory1 : CrossCuttinConcernsFactory
    {
        public override Caching CreateCahing()
        {
            return new RedisCahce();
        }

        public override Logging CreatLogger()
        {
            return new Log4Logged();
        }
    }
    public class Factory2 : CrossCuttinConcernsFactory
    {
        public override Caching CreateCahing()
        {
            return new RedisCahce();
        }

        public override Logging CreatLogger()
        {
            return new Nlogger();
        }
    }
    public class ProductManager
    {
        private CrossCuttinConcernsFactory _crossCuttinConcernsFactory;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttinConcernsFactory crossCuttinConcernsFactory)
        {
            _crossCuttinConcernsFactory = crossCuttinConcernsFactory;
            _logging = _crossCuttinConcernsFactory.CreatLogger();
            _caching = _crossCuttinConcernsFactory.CreateCahing();
        }
        public void GetAll()
        {
            _logging.Log("logged");
            _caching.Cache("Data");
            Console.WriteLine("Product Listed!");
        }
    }  
}
