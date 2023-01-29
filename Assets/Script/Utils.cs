using System;
using System.Globalization;
using UnityEngine;

public static class Utils
{
    public static void SetDateTime (string key, DateTime value)
    {
        string convertedstotring = value.ToString(format: "u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(key, convertedstotring);
    }
    public static DateTime GetDateTime(string key, DateTime defaultvalue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string stored = PlayerPrefs.GetString(key);
            DateTime result = DateTime.ParseExact(s: stored, format: "u", CultureInfo.InvariantCulture);
            return result;
        }
        else
        {
            return defaultvalue;
        }
    }
}
