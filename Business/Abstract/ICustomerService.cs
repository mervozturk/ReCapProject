using Core.Utilities.Results.DataResultFolder;
using Core.Utilities.Results.ResultFolder;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        DataResult<List<Customer>> GetAll();
        DataResult<Customer> GetCustomerById(int Id);
        Result Add(Customer customer);
        Result Delete(Customer customer);
        Result Update(Customer customer);
    }
}
