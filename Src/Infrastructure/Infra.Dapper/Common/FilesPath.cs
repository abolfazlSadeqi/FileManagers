using Domain.Enums;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Dapper.Common;

public class FilesPath
{
    public static string CreatePathWithfileTypeClientCode(FileType fileType, int ClientCode)
        => "/" + ((int)fileType).ToString() + "/" + ClientCode + "/";


    public static string CreatePathWithfileTypeClientCodeDate(FileType fileType, int ClientCode)
       => "/" + ((int)fileType).ToString() + "/" + ClientCode + "/" + GetDateFormatPath() + "/";


    public static string GetDateFormatPath()
       => DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0');


}
