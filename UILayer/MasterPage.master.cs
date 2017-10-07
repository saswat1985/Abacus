using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObject;
using Uitlity;

public partial class MasterPage : System.Web.UI.MasterPage
{
    clsUserLogin objDal = new clsUserLogin();
    Utility objUtil = new Utility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionWrapper.UserId == 0)
        {
            Response.Redirect(@"~/Login.aspx", false);
        }
        else
        {
            if (!IsPostBack)
            {
                try
                {

                    lblWelcome.Text = SessionWrapper.UserName.ToString() + "--" + DateTime.Now.ToString();
                    objUtil.PopulateMainMenu(TopMenu, Convert.ToString(SessionWrapper.UserId));
                }
                catch (Exception ex)
                {
                    ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "-->" + ex.Message.ToString());
                }
            }

        }
    }

    protected void TopMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        try
        {
            string strOrgUrl = objUtil.GetNavigationURL(int.Parse(TopMenu.SelectedValue));
            //ErrorModule.WriteErrorErrFile("Top menu clicked", strOrgUrl);
            string strNavUrl = strOrgUrl.ToLower();
            string strRawUrl = GetCurrentURL();
            //ErrorModule.WriteErrorErrFile("Top menu clicked", strRawUrl);
            if (strNavUrl.IndexOf(strRawUrl) == -1 || strRawUrl == string.Empty)
            {
                if (strOrgUrl != "#")
                {
                    Response.Redirect("~/" + strOrgUrl, false);
                }
            }
        }
        catch (Exception ex)
        {

            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "-->" + ex.Message.ToString());
        }


    }
    private string GetCurrentURL()
    {
        string[] strArrPart = Request.CurrentExecutionFilePath.ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        string strRet = "";
        if (strArrPart.Length > 0)
            for (int intCnt = 1; intCnt < strArrPart.Length; intCnt++)
                strRet += strArrPart[intCnt] + "/";
        strRet = strRet.TrimEnd('/');
        return strRet;
    }
    protected void LnkBtn_Click(object sender, EventArgs e)
    {
        try
        {
            tblMstUserLoginDetail objuserLoginDetail = new tblMstUserLoginDetail();
            objuserLoginDetail.AuthId = new Guid(SessionWrapper.AuthToken);
            objuserLoginDetail.LogoutTime = DateTime.Now;

            objDal.InsertUpdateUserLoginDetail(objuserLoginDetail);

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }

            Response.Redirect(@"~/Default.aspx", false);
        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "-->" + ex.Message.ToString());
        }
    }
}
