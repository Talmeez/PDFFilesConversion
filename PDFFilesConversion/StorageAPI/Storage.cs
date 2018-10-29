using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using PDFFilesConversion.Constant;
using GroupDocs.Storage.Cloud.Sdk.Api;
using GroupDocs.Storage.Cloud.Sdk.Model.Requests;
using GroupDocs.Storage.Cloud.Sdk.Model;
namespace PDFFilesConversion.StorageAPI
{
    public class Storage
    {

        public StorageApi ObjStorageApi = new StorageApi(new GroupDocs.Storage.Cloud.Sdk.Configuration()
        {
            AppSid = ConfigurationManager.AppSettings["AppSid"].ToString(),
            AppKey = ConfigurationManager.AppSettings["AppKey"].ToString()
        });
        public void MoveFile(string FileName, string FilePath)
        {
            try
            {
                PostMoveFileRequest request = new PostMoveFileRequest();
                request.Dest = Constants.StorageDestinationFolder + "//" + FileName;
                request.Src = Constants.StorageConversionFolder + FilePath;
                var response = ObjStorageApi.PostMoveFile(request);
                if (response.Code != Constants.ResponseOkCode)
                {

                }
            }
            catch (Exception e)
            {

            }
        }
        public List<FileResponse> GetFilesList(string DirectoryName)
        {
            List<FileResponse> Fileslist = new List<FileResponse>();
            try
            {

                GetListFilesRequest request = new GetListFilesRequest();
                request.Path = DirectoryName;
                var response = ObjStorageApi.GetListFiles(request);
                Fileslist = response.Files;
                if (response.Code != Constants.ResponseOkCode)
                {

                }
            }
            catch (Exception e)
            {

            }
            return Fileslist;
        }
    }
}