using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DataObject;
using EntityRefObject;
using Uitlity;


public partial class Default : BasePage
{
    DataTable dt = null;
    MstExportData objMaster = null;    
    BulkDataUpload objDataUpload = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());

        }

    }

    private void BindGrid()
    {
        objDataUpload = new BulkDataUpload();
        grdvConvertImageData.DataSource = objDataUpload.GetConvertRecords();
        grdvConvertImageData.DataBind();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        objMaster = new MstExportData();

        if (btnFileUpload.HasFile)
        {
            if (btnFileUpload.PostedFile.ContentLength < AppKeyCollection.MaxExcelFileSize)
            {
                string fleUpload = Path.GetExtension(btnFileUpload.FileName.ToString());
                if (fleUpload.Trim().ToLower() == ".xls" | fleUpload.Trim().ToLower() == ".xlsx")
                {
                    btnFileUpload.SaveAs(Server.MapPath(AppKeyCollection.ExcelFilePath + btnFileUpload.FileName.ToString()));
                    string uploadedFile = (Server.MapPath(AppKeyCollection.ExcelFilePath + btnFileUpload.FileName.ToString()));

                    try
                    {
                        int pageSize = Convert.ToInt32(AppKeyCollection.ImageRecordSize);
                        dt = Utility.xlsInsert(uploadedFile);

                        objDataUpload = new BulkDataUpload();
                        objMaster.UploadBy = 1;
                        objMaster.ImageType = Convert.ToInt32(ddlImageType.SelectedValue);
                        objMaster.UploadPath = uploadedFile;
                        objMaster.FileCode = DateTime.Now.ToString().GetHashCode().ToString("x");
                        int recordId = objDataUpload.SqlBulkDataCopyMaster(dt, objMaster);
                        BindGrid();
                        MsgBox1("File uploaded sucessfully!!", this);
                        ddlImageType.SelectedValue = "0";

                    }
                    catch (Exception ex)
                    {
                        ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
                    }
                }
            }
            else
            {
                MsgBox1("File size should be less then 20 MB", this);
            }

        }
        else
        {
            MsgBox1("Please Browse file first", this);
        }

    }



    protected void grdvConvertImageData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string folderPath = string.Empty;
            switch (e.CommandName)
            {
                case "DownloadZip":
                    {
                        folderPath = AppKeyCollection.ZipFilePath;
                        break;
                    }
                case "DownloadExcel":
                    {
                        folderPath = AppKeyCollection.ExcelFilePath;
                        break;
                    }

                default:
                    break;
            }

            if (!string.IsNullOrEmpty(e.CommandArgument.TrimString()))
            {
                string fileName = Path.GetFileName(e.CommandArgument.TrimString());
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "filename=" + fileName);
                Response.TransmitFile(Server.MapPath(folderPath) + fileName);
                Response.End();

            }

        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());

        }
    }
    protected void grdvConvertImageData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbn = e.Row.FindControl("lnkDownload") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lbn);

                LinkButton lnkDownloadExcel = e.Row.FindControl("lnkDownloadExcel") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkDownloadExcel);
            }

        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
        }
    }
    protected void btnTemplate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SampleTemplate.xlsx");
    }
}