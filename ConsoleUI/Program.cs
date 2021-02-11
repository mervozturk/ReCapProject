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
            CarTest();
            //ColorTest();
            //Brandtest();
            
        }
        private static void Test() 
        {
            Console.WriteLine("1-Ekleme");
            Console.WriteLine("2-Silme");
            Console.WriteLine("3-Güncelleme");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    
                    break;
                default:
                    break;
            }

        }

        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            int Id = 0;
            Console.WriteLine("1-Marka Id göre listele");
            Console.WriteLine("2-Renk Id göre listele ");
            Console.WriteLine("3-Tümünü Listele");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());
            List<Car> list=null;
            if (secim == 1 || secim == 2)
            {
                Console.Write("Id Giriniz:");
                Id = int.Parse(Console.ReadLine());
                if (secim == 1)
                {
                    list = carManager.GetCarsByBrandId(Id);
                }
                else
                {
                    list = carManager.GetCarsByColorId(Id);
                }
            }
            else if (secim == 3)
            {
                list = carManager.GetAll();
            }
            else
            {
                Console.WriteLine("Hata!!");
            }
            Console.WriteLine("-------------------");
            foreach (var item in list)
            {
                Console.WriteLine(item.Description+" "+item.ModelYear+" "+item.DailyPrice);
            }

        }

    }
}
