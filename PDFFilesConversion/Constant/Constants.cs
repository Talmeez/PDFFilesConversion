using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PDFFilesConversion.Constant
{
    public static class Constants
    {
        public static GroupDocs.Conversion.Cloud.Sdk.Api.Configuration APIConfiguration;
        static Constants()
        {
            APIConfiguration = new GroupDocs.Conversion.Cloud.Sdk.Api.Configuration()
            {
                AppSid = ConfigurationManager.AppSettings["AppSid"].ToString(),
                AppKey = ConfigurationManager.AppSettings["AppKey"].ToString()
            };
        }
        public const string StorageSourceFolder = "Source";
        public const string StorageDestinationFolder = "Output_Dir";
        public const string StorageConversionFolder = "conversion";
        public const int ResponseOkCode = 200;
    }
}