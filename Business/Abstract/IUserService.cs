using Core.Entities.Concrete;
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
        DataResult<User> GetUserById(int Id);
        DataResult<List<OperationClaim>> GetClaims(User user);
        DataResult<User> GetByMail(string email);
        Result Add(User user);
        Result Delete(User user);
        Result Update(User user);
    }
}
