using Business.Concrete;
using DataAcces.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2015, DailyPrice = 350, Description = "Siyah Mercedes E200" };
            Car car2 = new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2017, DailyPrice = 500, Description = "Kırmızı BMW M4" };
            Car car3 = new Car { Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2014, DailyPrice = 250, Description = "Siyah BMW 520i" };
            Car car4 = new Car { Id = 4, BrandId = 3, ColorId = 4, ModelYear = 2012, DailyPrice = 150, Description = "Gri Opel Astra" };
            Car car5 = new Car { Id = 5, BrandId = 4, ColorId = 5, ModelYear = 2015, DailyPrice = 700, Description = "Mavi Jaguar" };

            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            carManager.Add(car4);
            carManager.Add(car5);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------------------------------------------");

            foreach (var car in carManager.GetById(5))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------------------------------------------");

            carManager.Delete(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------------------------------------------");

            carManager.Update(new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2017, DailyPrice = 750, Description = "Kırmızı BMW M4 750 TL" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }










        
    }
}
