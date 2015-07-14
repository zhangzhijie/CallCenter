using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Fw
{
   public static class AppSetting
    {
       public static string AppTitle
       {
           get
           {
               return ConfigurationManager.AppSettings["AppTitle"];
           }
       }

       public static int PageSize
       {
           get
           {
               return int.Parse(ConfigurationManager.AppSettings["PageSize"]);
           }
       }

    }
}
