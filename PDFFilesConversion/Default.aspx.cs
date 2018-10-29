using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GroupDocs.Conversion.Cloud.Sdk;
using GroupDocs.Conversion.Cloud.Sdk.Api;
using GroupDocs.Conversion.Cloud.Sdk.Model.Requests;
using PDFFilesConversion.Constant;
using PDFFilesConversion.ConversionAPI;
using PDFFilesConversion.StorageAPI;
using System.IO;
using GroupDocs.Storage.Cloud.Sdk.Model;

namespace PDFFilesConversion
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            try
            {
                if (!IsPostBack)
                {
                    List<FileResponse> Fileslist = new List<FileResponse>();
                    Storage objStorage = new Storage();
                    Fileslist = objStorage.GetFilesList(Constants.StorageSourceFolder);
                    foreach (var file in Fileslist)
                    {
                        lbSourceFiles.Items.Add(file.Name);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSourceFiles.Items.Count > 0)
                {
                    lblStatus.Text = "";
                    btnConvert.Enabled = false;
                    Storage objStorage = new Storage();
                    Conversion objConversion = new Conversion();

                    foreach (ListItem item in lbSourceFiles.Items)
                    {
                        string OutFilePath = "";
                        OutFilePath = objConversion.ConvertFiletoPDF(item.ToString());
                        objStorage.MoveFile(Path.GetFileName(OutFilePath), OutFilePath);
                    }

                    List<FileResponse> Fileslist = new List<FileResponse>();
                    Fileslist = objStorage.GetFilesList(Constants.StorageDestinationFolder);
                    lbDestinationFiles.Items.Clear();
                    foreach (var file in Fileslist)
                    {
                        lbDestinationFiles.Items.Add(file.Name);
                    }
                }
                else
                {
                    lblStatus.Text = "Please upload a file!";
                }
                btnConvert.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }
    }
}