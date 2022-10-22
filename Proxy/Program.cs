using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase creditmanger = new CreditManagerProxy();
            Console.WriteLine(creditmanger.Calculate());
            Console.WriteLine(creditmanger.Calculate());
            Console.ReadLine();
        }
    }
    abstract class CreditBase
    {
        public abstract int Calculate();
    }
    class Creditmanger : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        private Creditmanger _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new Creditmanger();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
}

