using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "BMW", Model = "3.20", HirePrice = 250000 };

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.Discount = 90;

            Console.WriteLine(personalCar.Make+" "+personalCar.Model+" :");
            Console.WriteLine(specialOffer.HirePrice);

            Console.ReadLine();
        }
    }
    public abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }
    public class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    public class CommarcialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    public abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }
    public class SpecialOffer : CarDecoratorBase
    {
        public int Discount { get; set; }
        private CarBase _carBase;
        public SpecialOffer(CarBase carBase):base(carBase)
        {
            _carBase = carBase;
        }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get
            {
                return _carBase.HirePrice - _carBase.HirePrice * Discount/100;
            }
            set 
            {
            } 
        }
    }
}
