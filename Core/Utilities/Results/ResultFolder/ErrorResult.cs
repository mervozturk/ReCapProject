using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.ResultFolder
{
    public class ErrorResult : Result
    {
        public ErrorResult():base(false)
        {

        }
        public ErrorResult(bool success, string message) : base(false, message)
        {

        }
        public ErrorResult(bool success) : base(false)
        {

        }
        public ErrorResult(string message) : base(false,message)
        {

        }
    }
}
