using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServices.Helper
{
    public class DepartmentSettings
    {
        public static string UploadFile(IFormFile file,string FolderName)
        {

            //1-Get Folder Path

          //  2-var FolderPath = @"C:\\Users\\DELL\\source\\repos\\WebApplication4\\WebApplication4\\wwwroot\\Files\\Images\\";
          var FolderPath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files",FolderName);
            //Get File Name 
            var FileName = $"{Guid.NewGuid()}-{file.FileName}";
            //3-Compine Folder Path =FilePAth

            var FilePath=Path.Combine(FolderPath,FileName);
            //4-Save File
            using var fileStream = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(fileStream);
            return FileName;
        }
    }
}
