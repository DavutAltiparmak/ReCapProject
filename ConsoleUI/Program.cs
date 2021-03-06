﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCar();

            //TestBrand();

            //TestColor();

            UserCustomerRentalTest();
        }

        private static void UserCustomerRentalTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            User user1 = new User
            {
                Email = "davutaltiparmak3@gmail.com", FirstName = "Davut", LastName = "Altıparmak",
                Password = "12345"
            };

            User user2 = new User
            {
                Email = "aliveli@gmail.com",
                FirstName = "Ali",
                LastName = "Veli",
                Password = "54321"
            };

            User user3 = new User
            {
                Email = "ahmetdeli@gmail.com",
                FirstName = "Ahmet",
                LastName = "Deli",
                Password = "abcde"
            };


            Customer customer1 = new Customer {UserId = 1, CompanyName = "Altıparmak Holding"};
            Customer customer2 = new Customer {UserId = 2, CompanyName = "Veli Holding"};
            Customer customer3 = new Customer {UserId = 3, CompanyName = "Deli Holding"};

            Rental rental1 = new Rental {CarId = 1, CustomerId = 1, RentDate = DateTime.Now};
            Rental rental2 = new Rental {CarId = 1, CustomerId = 2, RentDate = DateTime.Now};
            Rental rental3 = new Rental {CarId = 2, CustomerId = 2, RentDate = DateTime.Now};
            Rental rental4 = new Rental {CarId = 4, CustomerId = 3, RentDate = DateTime.Now};


            //userManager.Add(user3);
            //customerManager.Add(customer3);
            rentalManager.Add(rental4);
            var result = rentalManager.Add(rental4).Message;
            Console.WriteLine(result);
            //rentalManager.Return(rental4);

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.UserId + " " + customer.CompanyName);
            }

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + " " + rental.ReturnDate.ToString());
            }
        }

        private static void TestColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("----------GetAll----------");

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("----------GetById----------");

            var result = colorManager.GetById(1);
            Console.WriteLine(result.Data.ColorName);

            Console.WriteLine("----------Add----------");

            Color colorToAdd = new Color { ColorName = "Aqua" };
            colorManager.Add(colorToAdd);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("----------Update----------");

            colorManager.Update(new Color { ColorId = 3, ColorName = "Light Blue" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("----------Delete----------");

            Color colorToDelete = new Color { ColorId = 7, ColorName = "Orange" };
            colorManager.Delete(colorToDelete);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void TestBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("----------GetAll----------");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("----------GetById----------");

            var result = brandManager.GetById(1);
            Console.WriteLine(result.Data.BrandName);

            Console.WriteLine("----------Add----------");

            Brand brandToAdd = new Brand {BrandName = "Fiat"};
            brandManager.Add(brandToAdd);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("----------Update----------");

            brandManager.Update(new Brand {BrandId = 5, BrandName = "Tesla V2"});
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("----------Delete----------");

            Brand brandToDelete = new Brand {BrandId = 7, BrandName = "Honda"};
            brandManager.Delete(brandToDelete);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void TestCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car
            {
                CarName = "Mercedes E200", BrandId = 1, ColorId = 1, ModelYear = 2015, DailyPrice = 350,
                Description = "Siyah Mercedes E200"
            };
            Car car2 = new Car
            {
                CarName = "BMW M4", BrandId = 2, ColorId = 2, ModelYear = 2017, DailyPrice = 500, Description = "Kırmızı BMW M4"
            };
            Car car3 = new Car
            {
                CarName = "BMW 520i", BrandId = 2, ColorId = 1, ModelYear = 2014, DailyPrice = 250,
                Description = "Siyah BMW 520i"
            };
            Car car4 = new Car
            {
                CarName = "Audi A6", BrandId = 3, ColorId = 5, ModelYear = 2012, DailyPrice = 150, Description = "Gri Audi A6"
            };
            Car car5 = new Car
            {
                CarName = "Volvo S60", BrandId = 4, ColorId = 3, ModelYear = 2015, DailyPrice = 700,
                Description = "Mavi Volvo S60"
            };

            Console.WriteLine("----------GetAll----------");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("----------GetById----------");

            var result = carManager.GetById(1);
            Console.WriteLine(result.Data.CarName);

            Console.WriteLine("----------Add----------");

            carManager.Add(car5);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("----------Update----------");

            carManager.Update(new Car
            {
                Id = 1002, BrandId = 4, CarName = "Volvo 2", ColorId = 3, ModelYear = 2015, DailyPrice = 700,
                Description = "Güncellenmiş Volvo"
            });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("----------Delete----------");


            Car car6 = new Car
            {
                Id = 7, CarName = "BMW 520i", BrandId = 2, ColorId = 1, ModelYear = 2014, DailyPrice = 250,
                Description = "Siyah BMW 520i"
            };
            carManager.Delete(car6);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
