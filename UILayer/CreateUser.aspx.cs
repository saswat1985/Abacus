using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObject;
using Uitlity;
using System.Web.Services;

public partial class CreateUser : BasePage
{
    Utility objUtil = new Utility();
    UserManagment objUser = new UserManagment();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                objUtil.FillDDL<List<tblIPMaster>>(ddlIPAddress, objUser.GetIPList(), "Id", "IPAddress");
                objUtil.FillDDL<List<MstLanguage>>(ddlLanguage, objUser.GetLangualeList(), "Id", "LanguageName", false);
                objUtil.FillDDL<List<aspnet_Roles>>(ddlUserRole, objUser.GetUserRoles(), "RoleId", "RoleName");

            }
            catch (Exception ex)
            {
                ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
            }


        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string userCode = string.Empty;
            tblMstUserMaster objMaster = new tblMstUserMaster();
            tblMstUserDetail objDetail = new tblMstUserDetail();

            objMaster.UserName = txtUserName.Text.TrimString();
            objMaster.Language = Convert.ToInt32(ddlLanguage.SelectedValue);
            objMaster.IsActive = true;
            objMaster.UserEntryId = SessionWrapper.UserId;
            objMaster.UserEntryDate = DateTime.Now;
            //objMaster.Password = Utility.GeneratePassword();
            objMaster.Password = AppKeyCollection.DefaultPwd;
            objMaster.RoleId = Convert.ToInt32(ddlUserRole.SelectedValue);

            objDetail.IPAllowed = Convert.ToInt32(ddlIPAddress.SelectedValue);
            objDetail.FirstName = txtFirstName.Text.TrimString();
            objDetail.LastName = txtLastName.Text.TrimString();
            objDetail.EmailId = txtEmailId.Text.TrimString();
            objDetail.ContactNo = txtContactNo.Text.TrimString();
            objDetail.UserEntryDate = DateTime.Now;

            if (objUser.SaveUpdateUser(objMaster, objDetail, out userCode))
            {
                MsgBox1(string.Format("User Created with code {0}", userCode), this);
               // SendMail(objDetail.EmailId, objMaster.UserName, objMaster.Password);
                Reset();
            }

        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
        }

    }

    private bool SendMail(string toMail, string userName, string password)
    {
        bool Result = false;
        MailSMSHandler objUtility = null;
        string fromMail, subject, emailBody;
        try
        {
            fromMail = AppKeyCollection.FromMail;
            subject = AppKeyCollection.WelcomeNote;
            emailBody = CreateMailBody.GetUserWelcomeNote(userName, password);
            objUtility = new MailSMSHandler(fromMail, toMail, emailBody, true, subject);
            Result = objUtility.sendMail();
        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
        }
        return Result;

    }

    public void Reset()
    {
        txtContactNo.Text = string.Empty;
        txtEmailId.Text = string.Empty;
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtUserName.Text = string.Empty;
        ddlIPAddress.SelectedValue = "0";
        ddlUserRole.SelectedValue = "0";
    }

    [WebMethod]
    public static bool CheckUserName(string userName, int userId)
    {
        bool result = false;
        try
        {
            result = new UserManagment().IsUserNameExist(userName, userId);
        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile("CheckUserName", ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
        }

        return result;
    }

    [WebMethod]
    public static bool CheckEmailID(string emailId, int userId)
    {
        bool result = false;
        try
        {
            result = new UserManagment().IsEmailIDExist(emailId, userId);
        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile("CheckEmailID", ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
        }

        return result;
    }
    [WebMethod]
    public static bool SendEmail(string userName)
    {
        bool result = false;
        try
        {

            string password = new UserManagment().GetUserPassword(userName);
            new CreateUser().SendMail(AppKeyCollection.FromMail, userName, password);
            result = true;

        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile("SendEmail", ex.StackTrace.ToString() + "--->" + ex.Message.ToString());
        }

        return result;
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
}