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
            Car ford = new Car
            {
                Id = 4,
                BrandId = 4,
                ColorId = 3,
                Description = "Y",
                DailyPrice = 2120,
                ModelYear = "2017"
            };

            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("**************** Renk Id'ye Göre Araç *****************");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("Arabanın Açıklaması: {0} Arabanın Yılı: {1} Günlük Ücret: {2}", car.Description, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("\n**************** Marka Id'ye Göre Araç *****************");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }


            //Console.WriteLine("\n****************Araç Eklendi***********************");
            //carManager.Add(ford); //araç eklemek için id alanı silinmeli
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("Arabanın Açıklaması: {0} Arabanın Yılı: {1} Günlük Ücret: {2}", car.Description, car.ModelYear, car.DailyPrice);
            //}

            //carManager.Update(ford);
            //Console.WriteLine("\n****************Araç Güncellendi***********************");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("Arabanın Açıklaması: {0} Arabanın Yılı: {1} Günlük Ücret: {2}", car.Description, car.ModelYear, car.DailyPrice);
            //}

            //carManager.Delete(ford);
            //Console.WriteLine("\n*****************Araç Silindi**********************");

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}





        }
    }
}
