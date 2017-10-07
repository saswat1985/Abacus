using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExtensionMethod
/// </summary>
public static class ExtensionMethod
{
    public static string TrimString(this object str)
    {
        string retValue = string.Empty;
        try
        {
            if (str != null)
            {
                retValue = Convert.ToString(str).Trim();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return retValue;
    }

    public static decimal TrimDecimal(this object str)
    {
        decimal retValue = 0;
        try
        {
            if (str != null)
            {
                retValue = Math.Round(Convert.ToDecimal(str), 2);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return retValue;
    }

    public static double TrimDouble(this object str)
    {
        double retValue = 0;
        try
        {
            if (str != null)
            {
                retValue = Math.Round(Convert.ToDouble(str), 2);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return retValue;
    }
}