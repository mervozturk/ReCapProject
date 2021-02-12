using Core.Utilities.Results.DataResultFolder;
using Core.Utilities.Results.ResultFolder;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        DataResult<List<Car>> GetAll();
        DataResult<List<Car>> GetCarsByBrandId(int Id);
        DataResult<List<Car>> GetCarsByColorId(int Id);
        Result Add(Car car);
        Result Delete(Car car);
        Result Update(Car car);
    }

}
