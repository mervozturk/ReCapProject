using Core.Utilities.Results.DataResultFolder;
using Core.Utilities.Results.ResultFolder;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        DataResult<List<Rental>> GetAll();
        DataResult<Rental> GetRentalById(int Id);
        Result Add(Rental rental);
        Result Update(Rental rental);
    }
}
