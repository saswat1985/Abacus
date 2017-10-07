using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for CreateMailBody
/// </summary>
public static class CreateMailBody
{


    public static string GetUserWelcomeNote(string m_UserName, string m_Password)
    {
        string Mailbody = "";
        try
        {
            StringBuilder SbMail = new StringBuilder();
            SbMail.AppendLine("<br>Dear User,</br>");
            SbMail.AppendLine("<br>Please find your Login detail below</br></P>");
            SbMail.AppendLine("<P><br>User Name :" + m_UserName + "</br>");
            SbMail.AppendLine("<br>Login Password :" + m_Password + "</br></br></P>");
            SbMail.AppendLine("<P><br>Please login to " + AppKeyCollection.WebSiteName + " for access portal.</P>");
            SbMail.AppendLine("<br>Thanks & Regards</br>");
            SbMail.AppendLine("<br>EDC Team</br>");
            SbMail.AppendLine("<br><br>***************************************************</br></br>");
            SbMail.AppendLine("<br>This is an auto generated email. Please do not reply to this email.</br>");
            SbMail.AppendLine("<br>***************************************************</br>");
            Mailbody = SbMail.TrimString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Mailbody;
    }
}