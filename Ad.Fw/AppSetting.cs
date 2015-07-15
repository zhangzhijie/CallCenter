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
       // 强插
       private static string forcedInsert;
       // 强拆
       private static string forcedHangUp;
       // 分机代答
       private static string extensionAnswer;
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

       public static string ForcedInsert
       {
           get
           {
               if (!string.IsNullOrWhiteSpace(forcedInsert))
               {
                   return forcedInsert;
               }
               forcedInsert = ConfigurationManager.AppSettings["ForcedInsert"];
               return forcedInsert;
           }
       }

       public static string ForcedHangUp
       {
           get
           {
               if (!string.IsNullOrWhiteSpace(forcedHangUp))
               {
                   return forcedHangUp;
               }
               forcedHangUp = ConfigurationManager.AppSettings["ForcedHangUp"];
               return forcedHangUp;
           }
       }

       public static string ExtensionAnswer
       {
           get
           {
               if (!string.IsNullOrWhiteSpace(extensionAnswer))
               {
                   return extensionAnswer;
               }
               extensionAnswer = ConfigurationManager.AppSettings["ExtensionAnswer"];
               return extensionAnswer;
           }
       }
    }
}
