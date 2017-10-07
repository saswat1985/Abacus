using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionWrapper
/// </summary>
public class SessionWrapper
{
    public SessionWrapper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region "Private Session Key Fields"

    private const string m_UserName = "UserName";
    private const string m_UserId = "UserId";
    private const string m_RoleId = "RoleId";
    private const string m_Menudata = "MenuData";
    private const string m_AuthToken = "AuthToken";
    private const string m_Culture = "Culture";



    #endregion "Private Session Key Fields"

    public enum Action
    {
        Get = 1,
        Set = 2
    }
    #region "Public Properties"
    public static string UserName
    {
        get { return GetFromSession<string>(m_UserName); }
        set { SetInSession<string>(m_UserName, value); }
    }
    public static int UserId
    {
        get { return GetFromSession<int>(m_UserId); }
        set { SetInSession<int>(m_UserId, value); }
    }
    public static int RoleId
    {
        get { return GetFromSession<int>(m_RoleId); }
        set { SetInSession<int>(m_RoleId, value); }
    }

    public static object MenuData
    {
        get { return GetFromSession<object>(m_Menudata); }
        set { SetInSession<object>(m_Menudata, value); }
    }

    public static string AuthToken
    {
        get { return GetFromSession<string>(m_AuthToken); }
        set { SetInSession<string>(m_AuthToken, value); }

    }
    public static string Culture
    {
        get { return GetFromSession<string>(m_Culture); }
        set { SetInSession<string>(m_Culture, value); }

    }

    #endregion "Public Properties"

    #region "Private Methods"

    /// <summary>
    /// Gets from session.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    private static T GetFromSession<T>(string key)
    {
        object obj = HttpContext.Current.Session[key];
        if (obj == null)
        {
            return default(T);
        }
        return (T)obj;
    }

    /// <summary>
    /// Sets the in session.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    private static void SetInSession<T>(string key, T value)
    {
        if (value == null)
            RemoveSession(key);
        else
            HttpContext.Current.Session[key] = value;
    }


    /// <summary>
    /// Sets the in session.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public static void RemoveSession(string key)
    {
        HttpContext.Current.Session.Remove(key);

    }
    #endregion "Private Methods"
}