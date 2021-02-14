using Core.Utilities.Results.DataResultFolder;
using Core.Utilities.Results.ResultFolder;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        DataResult<List<User>> GetAll();
        DataResult<User> GetCustomerById(int Id);
        Result Add(User user);
        Result Delete(User user);
        Result Update(User user);
    }
}
