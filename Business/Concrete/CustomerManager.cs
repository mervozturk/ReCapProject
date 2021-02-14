using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.DataResultFolder;
using Core.Utilities.Results.ResultFolder;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public Result Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public DataResult<Customer> GetCustomerById(int Id)
        {
            var result = _customerDal.Get(U => U.Id == Id);
            return new SuccessDataResult<Customer>(result);
        }

        public Result Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Uptated);
        }
    }
}
