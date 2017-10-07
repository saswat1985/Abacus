using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObject;
using Uitlity;
using System.Web.Services;

public partial class Login : System.Web.UI.Page
{
    tblMstUserMaster objVAL = new tblMstUserMaster();
    tblMstUserLoginDetail objVALLoginDetail = new tblMstUserLoginDetail();
    clsUserLogin objDal = new clsUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnFromEmail.Value = AppKeyCollection.FromMail;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        try
        {
            objVAL.Type = "CHECKLOGIN";
            objVAL.UserName = txtEmail.Text.TrimString();
            objVAL.Password = txtPassword.Text.TrimString();
            objDal.FnCheckLogin(objVAL);
            if (objVAL.OutRes == 0)
            {
                lblMessage.Text = "Invalid user name or password";
            }
            else
            {
                lblMessage.Text = string.Empty;
                //e.Authenticated = true;
                Session["UserID"] = SessionWrapper.UserId = objVAL.UserId;
                Session["RoleID"] = SessionWrapper.RoleId = objVAL.RoleId;
                Session["UserName"] = SessionWrapper.UserName = txtEmail.Text.TrimString();
                Session["AuthToken"] = SessionWrapper.AuthToken = Guid.NewGuid().ToString();
                SessionWrapper.Culture = objVAL.UserCulture;

                objVALLoginDetail.UserId = SessionWrapper.UserId;
                objVALLoginDetail.AuthId = new Guid(SessionWrapper.AuthToken);
                objVALLoginDetail.BrowserType = Request.Browser.Browser;
                objVALLoginDetail.IPAddress = Utility.GetUserIPAddress();             
                objVALLoginDetail.LoginTime = DateTime.Now;
                //DataTable dt = Utility.GetLocation(objVALLoginDetail.IPAddress);
                objDal.InsertUpdateUserLoginDetail(objVALLoginDetail);

                // now create a new cookie with this guid value
                Response.Cookies.Add(new HttpCookie("AuthToken", SessionWrapper.AuthToken));

                Response.Redirect("~/Default.aspx", false);
            }

        }
        catch (Exception ex)
        {
            //com.MsgBox1(ex.Message.ToString(),this);
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
            Response.Redirect("~/mdefault.htm", false);
        }
        
    }

    
   
}