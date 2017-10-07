using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uitlity;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnInit(EventArgs e)
    {
        try
        {
            if (SessionWrapper.UserId == 0)
            {
                Response.Redirect(@"~/Login.aspx", false);
            }
            else
            {
                if (SessionWrapper.RoleId != 1)
                {
                    string ipAddress = Utility.GetUserIPAddress();
                    if (!CheckUserIP(ipAddress, SessionWrapper.UserId))
                    {
                        Response.Redirect(@"~/UnAuthorisedAccess.aspx", false);
                    }
                }
                

            }
        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "-->" + ex.Message.ToString());
        }

    }

    private bool CheckUserIP(string userIpPAddress, int userId)
    {
        bool result = false;
        try
        {

            DataObject.UserManagment objUserMng = new DataObject.UserManagment();
            string assignIPAddress = objUserMng.GetUserIPAddress(userId);
            if (assignIPAddress.Equals(userIpPAddress))
            {
                result = true;
            }
            return result;

        }
        catch (Exception ex)
        {
            ErrorModule.WriteErrorErrFile(Request.RawUrl.ToString(), ex.StackTrace.ToString() + "-->" + ex.Message.ToString());
        }
        return result;
    }

    public void MsgBox1(string msg, Page refP)
    {
        Label lbl = new Label();
        lbl.ForeColor = System.Drawing.Color.Red;

        string lb = "window.alert('" + msg + "')";
        ScriptManager.RegisterClientScriptBlock(refP, this.GetType(), "UniqueKey", lb, true);
        refP.Controls.Add(lbl);
    }
}