using Core.Utilities.Results;
using Core.Utilities.Results.ResultFolder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public  class FileHelper 
    {
        public static IResult Delete(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public static IResult Upload(IFormFile file, string path, string newImageFileName)
        {
            using (FileStream fileStream = System.IO.File.Create(path + newImageFileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return new SuccessResult();
            }
        }
    }
}
