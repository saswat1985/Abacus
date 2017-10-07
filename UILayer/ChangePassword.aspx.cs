using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataObject;

public partial class ChangePassword : BasePage
{
    clsUserLogin objLogin = new clsUserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnChangePwd_Click(object sender, EventArgs e)
    {
        tblMstUserMaster objUser = null;
        if (txtPassword.Text.TrimString().Equals(txtConfirmPassword.Text.TrimString()))
        {
            objUser = new tblMstUserMaster();
            objUser.UserId = SessionWrapper.UserId;
            objUser.Password = txtConfirmPassword.Text.TrimString();
            if (objLogin.ChangePassowrd(objUser))
            {
                MsgBox1("Passowrd Change Sucessfully!!!", this);
            }
        }
        else
        {
            MsgBox1("New Password and Confirm Password must be equal.", this);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtConfirmPassword.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }
}