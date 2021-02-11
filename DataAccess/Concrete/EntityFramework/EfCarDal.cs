using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal: EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        //public List<CarDetailsDto> GetCarDetails()
        //{
        //    using (ReCapDatabaseContext context = new ReCapDatabaseContext())
        //    {
        //        var result = from car in context.Cars
        //                     join c in context.Colors
        //                      on car.BrandId equals b.BrandId
        //                     select new CarDetailsDto { BrandName = b.BrandName };
        //        return result.Tolist;
        //    }
        //}
    }
}
