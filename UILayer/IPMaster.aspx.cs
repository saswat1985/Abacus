using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObject;
using Uitlity;

public partial class IPMaster : BasePage
{
    clsIPMaster objDal = new clsIPMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                BindGrid();

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }

    private void BindGrid()
    {
        grdvIPList.DataSource = objDal.GetIPList();
        grdvIPList.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            tblIPMaster objMaster = new tblIPMaster();
            objMaster.IPAddress = txtIPAddress.Text.TrimString();
            objMaster.IsActive = true;
            objMaster.UserEntryId = SessionWrapper.UserId;
            objMaster.UserEntryDate = DateTime.Now;
            objMaster.UserEffectedDate = DateTime.Now;
            if (objDal.SaveUpdateIPDetail(objMaster))
            {
                MsgBox1("Record Saved Sucessfully",this);
                txtIPAddress.Text = string.Empty;
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
        }
       

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtIPAddress.Text = string.Empty;
    }
}