using Business.Concrete;
using Core.Entities;
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
            int secim = 0;
            while (secim != 999)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("1-Araba");
                Console.WriteLine("2-Marka");
                Console.WriteLine("3-Renk");
                Console.Write("secim giriniz: ");
                secim = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------");
                if (secim == 1)
                {
                    CarTest();
                }
                else if (secim == 2)
                {
                    Brandtest();
                }
                else if (secim == 3)
                {
                    ColorTest();
                }
                else if (secim == 999)
                {
                    Console.WriteLine("------İyi günler-------");
                }
                else
                {
                    Console.WriteLine("Hatalı giriş");
                }
            }


            //DtoTest();
        }

        private static int Menu()
        {
 
            Console.WriteLine("1-Ekleme");
            Console.WriteLine("2-Silme");
            Console.WriteLine("3-Güncelleme");
            Console.WriteLine("4-Listele");
            Console.Write("secim giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            return secim;
        }

        private static void CarTest()
        {
            int secim = Menu();
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();
            switch (secim)
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
            int secim = Menu();
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
                    Console.WriteLine("Hatalı giriş");
                    break;
            }
        }

        private static void ColorTest()
        {
            int secim = Menu();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color();
            switch (secim)
            {
                case 1:
                    Console.Write("Brand Name: ");
                    color.ColorName = Console.ReadLine();
                    Console.WriteLine(colorManager.Add(color).Message);
                    break;
                case 2:
                    Console.Write("Brand Id: ");
                    color.ColorId = int.Parse(Console.ReadLine());
                    Console.WriteLine(colorManager.Delete(color).Message);
                    break;
                case 3:
                    Console.Write("Brand Id: ");
                    color.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Brand Name: ");
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
                    Console.WriteLine("Hatalı giriş");
                    break;
            }
        }

        private static void CarListele()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            int Id = 0;
            Console.WriteLine("1-Marka Id göre listele");
            Console.WriteLine("2-Renk Id göre listele ");
            Console.WriteLine("3-Tümünü Listele");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());
            List<Car> list = null;
            if (secim == 1 || secim == 2)
            {
                Console.Write("Id Giriniz:");
                Id = int.Parse(Console.ReadLine());
                if (secim == 1)
                {
                    list = carManager.GetCarsByBrandId(Id).Data;
                }
                else
                {
                    list = carManager.GetCarsByColorId(Id).Data;
                }
            }
            else if (secim == 3)
            {
                list = carManager.GetAll().Data;
            }
            else
            {
                Console.WriteLine("Hata!!");
            }
            Console.WriteLine("-------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item.Description + " " + item.ModelYear + " " + item.DailyPrice);
            }

        }

    }
}
