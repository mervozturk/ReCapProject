using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.DataResultFolder;
using Core.Utilities.Results.ResultFolder;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public Result Add(Car car)
        { 
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult( Messages.Deleted);
        }

        public DataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(), Messages.Listed);
        }

        public DataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            List<Car> result = _carDal.GetAll(B => B.BrandId == Id);
            return new SuccessDataResult < List < Car >>( result, Messages.Listed);
        }

        public DataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult < List < Car >> (_carDal.GetAll(C => C.ColorId == Id),Messages.Listed);
        }

        public Result Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Uptated);
        }
    }

}
