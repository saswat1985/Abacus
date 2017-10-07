using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;

/// <summary>
/// Summary description for MailSMSHandler
/// </summary>
public class MailSMSHandler
{
	 private string FromMail { get; set; }
    private string ToMail { get; set; }
    private string Body { get; set; }
    private Boolean IsHTML { get; set; }
    private string Subject { get; set; }

    private string SmsUserName { get; set; }
    private string SmsPwd { get; set; }
    private string SmsSenderId { get; set; }
    private string SmsDomain { get; set; }


    public MailSMSHandler()
    {
        //this.SmsUserName = AppKeyCollection.SmsUserName;
        //this.SmsPwd = AppKeyCollection.SmsPwd;
        //this.SmsSenderId = AppKeyCollection.SmsSenderId;
        //this.SmsDomain = AppKeyCollection.SmsDomain;


    }

    public MailSMSHandler(string m_FromMail, string m_ToMail, string m_Body, bool m_IsHTML, string m_Subject)
    {
        this.FromMail = m_FromMail;
        this.ToMail = m_ToMail;
        this.Subject = m_Subject;
        this.IsHTML = m_IsHTML;
        this.Body = m_Body;       
    }

    public bool sendMail()
    {
        SmtpClient smtpClient = new SmtpClient();
        MailMessage message = new MailMessage();
        bool status = false;

        try
        {

            MailAddress fromAddress = new MailAddress(FromMail, "", System.Text.Encoding.UTF8);
            message.From = fromAddress;//here you can set address
            message.To.Add(ToMail);//here you can add multiple to
            message.Subject = Subject;//subject of email
            message.SubjectEncoding = Encoding.UTF8;           
            message.IsBodyHtml = IsHTML;//To determine email body is html or not
            message.Body = Body;
            message.BodyEncoding = Encoding.UTF8;
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            status = true;
        }

        catch (Exception ex)
        {
            throw ex;
            //throw exception here you can write code to handle exception here
        }

        return status;
    }

    //public bool SendSingleSMS(string smsElement, string mobileNo)
    //{
    //    string result = string.Empty;
    //    bool issmssent = false;
    //    try
    //    {
    //        result = APICall("http://" + this.SmsDomain + "/sendsms.php?username=" + this.SmsUserName + "&password=" + this.SmsPwd + "&sender=" + this.SmsSenderId + "&mobile=" + mobileNo + "&message=" + smsElement + "&route=T");
    //        if (Common.IsNumber(result))
    //        {
    //            issmssent = true;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return issmssent;
    //}

    //private string APICall(string url)
    //{
    //    try
    //    {
    //        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
    //        HttpWebResponse httpResponse = (HttpWebResponse)httpreq.GetResponse();
    //        StreamReader objStreamReader = new StreamReader(httpResponse.GetResponseStream());
    //        string result = objStreamReader.ReadToEnd();
    //        objStreamReader.Close();
    //        return result;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //public static string GetTransCode(string moduleName)
    //{
    //    try
    //    {
    //        return new ClsBALTransaction().GetTransectionCode(moduleName);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}

}