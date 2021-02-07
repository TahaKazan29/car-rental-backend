using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();    
            //BrandTest();
            //ColorTest();

        }

        private static void ColorTest()
        {
            Color color = new Color
            {
                Id = 1002,
                Name = "Sarı"
            };

            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Delete(color);
            foreach (var colorr in colorManager.GetAll())
            {
                Console.WriteLine("Id : {0} Marka: {1}", colorr.Id, colorr.Name);
            }
        }

        private static void BrandTest()
        {
            Brand brand = new Brand
            {
                Id = 1002,
                Name = "Fiat Egea"
            };

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Update(brand);
            foreach (var brandd in brandManager.GetAll())
            {
                Console.WriteLine("Id : {0} Marka: {1}", brandd.Id, brandd.Name);
            }
        }

        private static void CarTest()
        {
            Car ford = new Car
            {
                Id = 1002,
                BrandId = 4,
                ColorId = 3,
                Description = "Silicem",
                DailyPrice = 2120,
                ModelYear = "2017"
            };
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Delete(ford);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Araç Açıklaması : {0} Marka: {1} Renk: {2} Günlük Fiyatı: {3}", car.Description, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
