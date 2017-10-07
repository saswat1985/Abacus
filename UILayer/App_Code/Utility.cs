using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.UI.WebControls;
using DataObject;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    DataTable m_DTMenu;

    clsMenuManagment objMenu = new clsMenuManagment();

    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void FillDDL<T>(DropDownList ddl, T listSource, string strid, string strtext, bool bindZeroIndex = true)
    {
        ddl.DataSource = listSource;
        ddl.DataValueField = strid;
        ddl.DataTextField = strtext;
        ddl.DataBind();
        if (bindZeroIndex)
            ddl.Items.Insert(0, new ListItem("--Please Select--", "0"));
    }

    public static void CreateMissingDirectory(string path)
    {
        try
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public static DataTable xlsInsert(string pth)
    {
        try
        {
            string strcon = string.Empty;
            if (Path.GetExtension(pth).ToLower().Equals(".xls"))
            {
                strcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pth + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
            }
            else if (Path.GetExtension(pth).ToLower().Equals(".xlsx"))
            {
                strcon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pth + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            }
            string strselect = "Select * from [Sheet1$]";
            DataTable exDT = new DataTable();
            using (OleDbConnection excelCon = new OleDbConnection(strcon))
            {
                try
                {
                    excelCon.Open();
                    using (OleDbDataAdapter exDA = new OleDbDataAdapter(strselect, excelCon))
                    {
                        exDA.Fill(exDT);
                    }
                }
                catch (OleDbException oledb)
                {
                    throw new Exception(oledb.Message.ToString());
                }
                finally
                {
                    excelCon.Close();
                }
                for (int i = exDT.Rows.Count - 1; i >= 0; i--)
                {
                    if (exDT.Rows[i]["customername"] == DBNull.Value)
                    {
                        exDT.Rows[i].Delete();
                    }
                }
                exDT.AcceptChanges();  // refresh rows changes
                if (exDT.Rows.Count == 0)
                {
                    throw new Exception("File uploaded has no record found.");
                }
                return exDT;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public static string GenrateHTML(DataTable dtrecord)
    {
        StringBuilder htmlString = new StringBuilder();
        //htmlString.Append("<div style='height: 2808px; width: 881px;'>");
        htmlString.Append("<table style='font-family: Batang; color: black; font-size: xx-small;'>");
        foreach (DataRow row in dtrecord.Rows)
        {
            htmlString.Append("<tr>");
            htmlString.Append("<td>" + row.ItemArray[0] + "</td>");
            htmlString.Append("<td>");
            int i = 0;
            foreach (var item in row.ItemArray.Skip(1))
            {
                htmlString.Append("<span style='margin: 0px 0px 0px 15px;'>");
                htmlString.Append(item);
                if (i == 6 || i == 12 || i == 18 || i == 23)
                {
                    htmlString.Append("</span><br />");
                }
                else
                {
                    htmlString.Append("</span>");
                }
                i++;
            }

            htmlString.Append("</td></tr>");
            htmlString.Append("<tr><td colspan='2' style='height: 10px;'></td></tr>");


        }
        htmlString.Append("</table>");
        //htmlString.Append("</div>");

        return htmlString.TrimString();
    }

    public static string DoubleDateTime()
    {
        return DateTime.Now.Day.TrimString() + DateTime.Now.Month.TrimString() + DateTime.Now.Year.TrimString();
    }

    public static int GetPageCount(int rowCount, int pageSize)
    {
        int returnResult = 0;
        if (rowCount % pageSize > 0)
        {
            int result = Convert.ToInt32(rowCount / pageSize);
            returnResult = result + 1;
        }
        else
        {
            returnResult = Convert.ToInt32(rowCount / pageSize);
        }
        return returnResult;

    }

    public static string GetUserIPAddress()
    {
        string ipaddress = string.Empty;
        try
        {
            ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ipaddress;
    }

    public void PopulateMainMenu(Menu CommonMenu, string UserID)
    {

        DataTable menuData = UserMenuList(UserID);
        DataView dView = new DataView(menuData);
        dView.RowFilter = "ParentID=0";  // Checking for root item of menu control i.e. which have parent id 0

        foreach (DataRowView drView in dView)
        {
            MenuItem newMenuItem = new MenuItem("" + drView["MenuText"].ToString() + "", drView["MenuId"].ToString());
            CommonMenu.Items.Add(newMenuItem);
            //CODE FOR CONVERTING TO XML-BY BADRISH
            //CODE FOR CONVERITNG TO XML END
            BindChildMenuItems(menuData, newMenuItem);
        }
    }

    private DataTable UserMenuList(string UserID)
    {
        List<string> objMenuData = null;
        DataTable menuData = GetMainMenuTable(UserID);
        if (menuData != null && menuData.Rows.Count > 0)
        {
            objMenuData = new List<string>();
            foreach (DataRow item in menuData.Rows)
            {
                objMenuData.Add(item["NavigateURL"].ToString());
            }
            SessionWrapper.MenuData = objMenuData;
        }
        return menuData;
    }

    private DataTable GetMainMenuTable(string strUserName)
    {
        m_DTMenu = new DataTable();
        //Getting menu from proc uspMenuMaster
        m_DTMenu = objMenu.GetMainMenuTable(strUserName);
        return m_DTMenu;

    }

    private void BindChildMenuItems(DataTable menuData, MenuItem newMenuItem)
    {
        DataView dView = new DataView(menuData);
        dView.RowFilter = "ParentId=" + newMenuItem.Value.ToString();

        foreach (DataRowView drView in dView)
        {
            MenuItem newChildMenuItem = new MenuItem(drView["MenuText"].ToString(), drView["MenuId"].ToString());
            newMenuItem.ChildItems.Add(newChildMenuItem);
            //CODE FOR CONVERTING TO XML-BY BADRISH
            //CODE FOR CONVERITNG TO XML END
            BindChildMenuItems(menuData, newChildMenuItem);
        }
    }

    public string GetNavigationURL(int intMenuItemValue)
    {
        try
        {
            return objMenu.GetNavigationURL(intMenuItemValue);
        }
        catch (Exception ex)
        {            
            throw ex;
        }
        

    }

    public static string GeneratePassword()
    {
        int lengthOfPassword = 8;
        string guid = Guid.NewGuid().ToString().Replace("-", "");
        return guid.Substring(0, lengthOfPassword);

    }
}