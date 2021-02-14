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
            //CustomerTest();
            RentalTest();
        }

        private static void RentalTest()
        {
            Rental rental = new Rental
            {
                Id = 4,
                CarId = 3,
                CustomerId = 1,
                RentDate = DateTime.Today,
                ReturnDate = DateTime.Now
            };

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Delete(rental);
            var result = rentalManager.GetRentalDetails();
            if (result.Success)
            {
                foreach (var rentall in result.Data)
                {
                    Console.WriteLine("CarName : {0} CustomerName: {1} RentDate: {2} : ReturnDate{3}",
                        rentall.CarName, rentall.CustomerName, rentall.RentDate, rentall.ReturnDate);
                }
            }
        }

        private static void CustomerTest()
        {
            Customer sahinler = new Customer
            {
                CompanyName = "Toroslar"
            };

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(sahinler);
            Console.WriteLine(result.Success);
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
            foreach (var colorr in colorManager.GetAll().Data)
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
            foreach (var brandd in brandManager.GetAll().Data)
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

            //carManager.Delete(ford);
            Console.WriteLine(carManager.GetAll().Message);
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araç Açıklaması : {0} Marka: {1} Renk: {2} Günlük Fiyatı: {3}", car.Description, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
