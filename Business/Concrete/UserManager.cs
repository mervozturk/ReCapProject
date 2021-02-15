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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public Result Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);

        }

        public DataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public DataResult<User> GetUserById(int Id)
        {
            var result = _userDal.Get(U => U.Id == Id);
            return new SuccessDataResult<User>(result);
        }

        public Result Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Uptated);

        }
    }
}
