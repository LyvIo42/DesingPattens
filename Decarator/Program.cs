using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decarator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Make = "Bmw", Model = "3.20", HirePrice = 2500 };

            SpacialOffer specialOffer = new SpacialOffer(personelCar);
            specialOffer.DiscountPercentage = 10;//indirim için
            Console.WriteLine("Concrete : {0}",personelCar.HirePrice);
            Console.WriteLine("Special offer:{0}", specialOffer.HirePrice);
            

            Console.ReadLine();
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }
    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    class CommerCialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }
    class SpacialOffer : CarDecoratorBase
    {
        //indirim için
        public int DiscountPercentage { get; set; }
        //
        private readonly CarBase _carBase;

        public SpacialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            //indirim için
            get { return _carBase.HirePrice - _carBase.HirePrice * DiscountPercentage / 100; }
            set { }
            
        }

    }
}
