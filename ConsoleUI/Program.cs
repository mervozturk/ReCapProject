using Business.Concrete;
using Core.Entities;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu();
            //DtoTest();                       
        }

        private static void RentalTest()
        {
            int secim = CRUDMenu();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            switch (secim)
            {
                case 1:
                    Console.Write("Car ID: ");
                    rental.CarId = int.Parse(Console.ReadLine()); ;
                    Console.Write("Customer ID: ");
                    rental.CustomerId = int.Parse(Console.ReadLine()); ;
                    Console.Write("Rent date: ");
                    rental.RentDate = Console.ReadLine();
                    Console.WriteLine(rentalManager.Add(rental).Message);
                    break;
                case 2:
                    Console.WriteLine(" Kayıt silemezsiniz! ");
                    break;
                case 3:
                    Console.Write("Id: ");
                    rental.Id = int.Parse(Console.ReadLine());
                    Console.Write("Car ID: ");
                    rental.CarId = int.Parse(Console.ReadLine()); ;
                    Console.Write("Customer ID: ");
                    rental.CustomerId = int.Parse(Console.ReadLine()); ;
                    Console.Write("Rent date: ");
                    rental.RentDate = Console.ReadLine();
                    Console.Write("Return date: ");
                    rental.ReturnDate =Console.ReadLine();
                    Console.WriteLine(rentalManager.Update(rental).Message);
                    break;
                case 4:
                    foreach (var item in rentalManager.GetAll().Data)
                    {
                        Console.WriteLine(item.CustomerId + " " + item.RentDate + " " + item.ReturnDate);
                    }
                    break;
                default:
                    Console.WriteLine("Hatalı giriş");
                    break;
            }
        }

        private static void CustomerTest()
        {
            int secim = CRUDMenu();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer ();
            switch (secim)
            {
                case 1:
                    Console.Write("User ID: ");
                    customer.UserId = int.Parse(Console.ReadLine()); ;
                    Console.Write("Company Name: ");
                    customer.CompanyName = Console.ReadLine();
                    Console.WriteLine(customerManager.Add(customer).Message);
                    break;
                case 2:
                    Console.Write("User Id: ");
                    customer.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine(customerManager.Delete(customer).Message);
                    break;
                case 3:
                    Console.Write("Customer Id: ");
                    customer.Id = int.Parse(Console.ReadLine());
                    Console.Write("User ID: ");
                    customer.UserId = int.Parse(Console.ReadLine()); ;
                    Console.Write("Company Name: ");
                    customer.CompanyName = Console.ReadLine();
                    Console.WriteLine(customerManager.Update(customer).Message);
                    break;
                case 4:
                    foreach (var item in customerManager.GetAll().Data)
                    {
                        Console.WriteLine(item.CompanyName);
                    }
                    break;
                default:
                    Console.WriteLine("Hatalı giriş");
                    break;
            }
        }

        private static void UserTest()
        {
            int secim = CRUDMenu();
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User();
            switch (secim)
            {
                case 1:
                    Console.Write("FirstName: ");
                    user.FirstName = Console.ReadLine();
                    Console.Write("LastName: ");
                    user.LastName = Console.ReadLine();
                    Console.Write("Email: ");
                    user.Email = Console.ReadLine();
                    Console.Write("Password: ");
                    //user.Password = Console.ReadLine();
                    Console.WriteLine(userManager.Add(user).Message);
                    break;
                case 2:
                    Console.Write("User Id: ");
                    user.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine(userManager.Delete(user).Message);
                    break;
                case 3:
                    Console.Write("User Id: ");
                    user.Id = int.Parse(Console.ReadLine());
                    Console.Write("FirstName: ");
                    user.FirstName = Console.ReadLine();
                    Console.Write("LastName: ");
                    user.LastName = Console.ReadLine();
                    Console.Write("Email: ");
                    user.Email = Console.ReadLine();
                    Console.Write("Password: ");
                    //user.Password = Console.ReadLine();
                    Console.WriteLine(userManager.Update(user).Message);
                    break;
                case 4:
                    foreach (var item in userManager.GetAll().Data)
                    {
                        Console.WriteLine(item.FirstName + " " + item.LastName);
                    }
                    break;
                default:
                    Console.WriteLine("Hatalı giriş");
                    break;
            }
        }

        private static void Menu()
        {
            int choice = 0;
            while (choice != 999)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("1-Car");
                Console.WriteLine("2-Brand");
                Console.WriteLine("3-Color");
                Console.WriteLine("4-User");
                Console.WriteLine("5-Customer");
                Console.WriteLine("6-Rental");
                Console.WriteLine("999-Exit");
                Console.Write("Choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------");
                if (choice == 1)
                {
                    CarTest();
                }
                else if (choice == 2)
                {
                    Brandtest();
                }
                else if (choice == 3)
                {
                    ColorTest();
                }
                else if (choice==4)
                {
                    UserTest();
                }
                else if (choice == 5)
                {
                    CustomerTest();
                }
                else if (choice == 6)
                {
                    RentalTest();
                }
                else if (choice == 999)
                {
                    Console.WriteLine("------Have a good day-------");
                }
                else
                {
                    Console.WriteLine("Hatalı giriş");
                }
            }
        }

        private static int CRUDMenu()
        {  
            Console.WriteLine("1-Add");
            Console.WriteLine("2-Delete");
            Console.WriteLine("3-Update");
            Console.WriteLine("4-List");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------------");
            return choice;
        }

        private static void CarTest()
        {
            int choice = CRUDMenu();
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();
            switch (choice)
            {
                case 1:
                    Console.Write("Color Id: ");
                    car.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Brand Id: ");
                    car.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Car Name: ");
                    car.CarName = Console.ReadLine();
                    Console.Write("Description:");
                    Console.Write("Model Year:");
                    car.ModelYear = int.Parse(Console.ReadLine());
                    car.Description = Console.ReadLine();
                    Console.Write("Daily Price:");
                    car.DailyPrice = decimal.Parse(Console.ReadLine());
                    Console.WriteLine(carManager.Add(car).Message);
                    break;
                case 2:
                    Console.Write("Car Id: ");
                    car.Id = int.Parse(Console.ReadLine());
                    carManager.Delete(car);
                    break;
                case 3:
                    Console.Write("Car Id: ");
                    car.Id = int.Parse(Console.ReadLine());
                    Console.Write("Color Id: ");
                    car.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Brand Id: ");
                    car.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Car Name: ");
                    car.CarName = Console.ReadLine();
                    Console.Write("Description:");
                    Console.Write("Model Year:");
                    car.ModelYear = int.Parse(Console.ReadLine());
                    car.Description = Console.ReadLine();
                    Console.Write("Daily Price:");
                    car.DailyPrice = decimal.Parse(Console.ReadLine());
                    Console.WriteLine(carManager.Update(car).Message);
                    break;
                case 4:
                    CarListele();
                    break;
                default:
                    Console.WriteLine("Hatalı giriş");
                    break;
            }
        }

        private static void DtoTest()
        {
            EfCarDal efCar = new EfCarDal();
            foreach (var item in efCar.GetCarDetails())
            {
                Console.WriteLine(item.CarName + " " + item.ColorName + " " + item.BrandName);
            }
        }

        private static void Brandtest()
        {
            int secim = CRUDMenu();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            switch (secim)
            {
                case 1:
                    Console.Write("Brand Name: ");
                    brand.BrandName = Console.ReadLine();
                    Console.WriteLine(brandManager.Add(brand).Message);
                    break;
                case 2:
                    Console.Write("Brand Id: ");
                    brand.BrandId = int.Parse(Console.ReadLine());
                    Console.WriteLine(  brandManager.Delete(brand).Message);
                    break;
                case 3:
                    Console.Write("Brand Id: ");
                    brand.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Brand Name: ");
                    brand.BrandName = Console.ReadLine();
                    Console.WriteLine(brandManager.Update(brand).Message);
                    break;
                case 4:
                    foreach (var item in brandManager.GetAll().Data)
                    {
                        Console.WriteLine(item.BrandName);
                    }
                    break;
                default:
                    Console.WriteLine("!!!Error!!!");
                    break;
            }
        }

        private static void ColorTest()
        {
            int choice = CRUDMenu();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color();
            switch (choice)
            {
                case 1:
                    Console.Write("Color Name: ");
                    color.ColorName = Console.ReadLine();
                    Console.WriteLine(colorManager.Add(color).Message);
                    break;
                case 2:
                    Console.Write("Color Id: ");
                    color.ColorId = int.Parse(Console.ReadLine());
                    Console.WriteLine(colorManager.Delete(color).Message);
                    break;
                case 3:
                    Console.Write("Color Id: ");
                    color.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Color Name: ");
                    color.ColorName = Console.ReadLine();
                    Console.WriteLine(colorManager.Update(color).Message);
                    break;
                case 4:
                    foreach (var item in colorManager.GetAll().Data)
                    {
                        Console.WriteLine(item.ColorName);
                    }
                    break;
                default:
                    Console.WriteLine("Eror");
                    break;
            }
        }

        private static void CarListele()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            int Id = 0;
            Console.WriteLine("1-By brand");
            Console.WriteLine("2-By color ");
            Console.WriteLine("3-All");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());
            List<Car> list = null;
            if (choice == 1 || choice == 2)
            {
                Console.Write("Id Giriniz:");
                Id = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    list = carManager.GetCarsByBrandId(Id).Data;
                }
                else
                {
                    list = carManager.GetCarsByColorId(Id).Data;
                }
            }
            else if (choice == 3)
            {
                list = carManager.GetAll().Data;
            }
            else
            {
                Console.WriteLine("!!Error!!");
            }
            Console.WriteLine("-------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item.Description + " " + item.ModelYear + " " + item.DailyPrice);
            }

        }

    }
}
