using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.DataResultFolder
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, bool success, string message) : base(data,false, message)
        {

        }

        public ErrorDataResult(T data, bool success) : base(data, false)
        {

        }
        public ErrorDataResult(T data, string message) : base(data, false,message)
        {

        }
        public ErrorDataResult(T data) : base(data, true)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
