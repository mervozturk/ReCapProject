using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using Core.Utilities.Results.DataResultFolder;
using Core.Utilities.Results.ResultFolder;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile file,CarImage carImage)
        {
            //if (!BusinessRules.Run(CheckIfImageCount(carImage.CarId)).Success) {
            //    return new ErrorResult();
            //}
            string targetFile = @"C:\Users\90542\source\repos\ReCapProject\Images";

            if (!Directory.Exists(targetFile))
            {
                Directory.CreateDirectory(targetFile);
            }

            string newImageFileName = RenameFileToGuid(file).Data;
            carImage.Date = DateTime.Now;
            carImage.ImagePath = targetFile +"\\"+ newImageFileName;
            FileHelper.Upload(file,targetFile,newImageFileName);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetCarImage(int CarId)
        {
            var result = _carImageDal.GetAll().Where(p => p.CarId == CarId).ToList();
            if (result.Count==0)
            {
                var defaultImage= _carImageDal.GetAll().Where(p => p.Id == 1).ToList();
                return new SuccessDataResult<List<CarImage>>(defaultImage);
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetImage(int Id)
        {
            var result = _carImageDal.GetAll().SingleOrDefault(p => p.Id == Id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Uptated);
        }

        private IResult CheckIfImageCount(int carId)
        {
            int result = _carImageDal.GetAll().Where(p => p.CarId == carId).Count();
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult IsExist(int carImageId)
        {
            var carImageExist = GetImage(carImageId);
            if (carImageExist.Data != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private static IDataResult<string> RenameFileToGuid(IFormFile file)
        {
            string[] fileNameSplit = file.FileName.Split('.');
            var extensionOfFile = "." + fileNameSplit[fileNameSplit.Length - 1];
            var result =
                DateTime.Now.Day.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" +
                DateTime.Now.Year.ToString() + "_" +
                Guid.NewGuid().ToString() + extensionOfFile;
            return new SuccessDataResult<string>(result);
        }
    }
}
