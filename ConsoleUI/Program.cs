using Business.Concrete;
using DataAcces.Concrete.EntityFramework;
using DataAcces.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { CarName = "Mercedes E200", BrandId = 1, ColorId = 1, ModelYear = 2015, DailyPrice = 350, Description = "Siyah Mercedes E200" };
            Car car2 = new Car { CarName = "BMW M4", BrandId = 2, ColorId = 2, ModelYear = 2017, DailyPrice = 500, Description = "Kırmızı BMW M4" };
            Car car3 = new Car { CarName = "BMW 520i", BrandId = 2, ColorId = 1, ModelYear = 2014, DailyPrice = 250, Description = "Siyah BMW 520i" };
            Car car4 = new Car { CarName = "Audi A6", BrandId = 3, ColorId = 5, ModelYear = 2012, DailyPrice = 150, Description = "Gri Audi A6" };
            Car car5 = new Car { CarName = "Volvo S60", BrandId = 4, ColorId = 3, ModelYear = 2015, DailyPrice = 700, Description = "Mavi Volvo S60" };

            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);
            //carManager.Add(car4);
            //carManager.Add(car5);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("---------------------------------------------------");

            carManager.Add(car3);

            Console.WriteLine("---------------------------------------------------");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("---------------------------------------------------");

            Car car6 = new Car { CarName = "a", BrandId = 1, ColorId = 1, DailyPrice = 0, Description = "Hatalı", ModelYear = 2000 };

            carManager.Add(car6);
        }
            
    }
}
