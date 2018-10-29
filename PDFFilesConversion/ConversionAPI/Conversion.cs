using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PDFFilesConversion.Constant;
using GroupDocs.Conversion.Cloud.Sdk;
using GroupDocs.Conversion.Cloud.Sdk.Api;
using GroupDocs.Conversion.Cloud.Sdk.Model;
using GroupDocs.Conversion.Cloud.Sdk.Model.Requests;
namespace PDFFilesConversion.ConversionAPI
{
    public class Conversion
    {
        public StorageApi ObjStorageApi = new StorageApi(Constants.APIConfiguration);
        public ConversionApi ObjConversionApi = new ConversionApi(Constants.APIConfiguration);
        public string ConvertFiletoPDF(string FileName)
        {
            string FilePath = "";
            try
            {
                var request = new ConvertToPdfRequest
                {
                    Request = new PdfConversionRequest
                    {
                        SourceFile = new ConversionFileInfo() { Folder = Constants.StorageSourceFolder, Name = FileName, Password = "" },
                        Options = new PdfSaveOptionsDto()
                    }
                };
                var response = ObjConversionApi.ConvertToPdf(request);
                FilePath = response.Href.ToString();
            }
            catch (Exception ex)
            {

            }
            return FilePath.Substring(FilePath.IndexOf(Constants.StorageConversionFolder) + Constants.StorageConversionFolder.Length);
        }
    }
}