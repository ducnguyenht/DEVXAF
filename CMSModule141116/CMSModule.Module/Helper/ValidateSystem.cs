﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;


public class ValidateSystem
{
    public bool checkNullBlank(string str)
    {
        if (str.Trim().Equals("") || str == null)
        {
            return true;
        }
        return false;
    }

    public bool CheckAlias(string alias)
    {
        if (!alias.Contains(" "))
            if (!alias.Contains("-"))
                return true;
        if (string.IsNullOrEmpty(alias))
            return false;
        if (alias.Contains(" "))
            return false;
        if (!alias.Contains("-"))
            return false;
        return true;
    }
    public bool isNumber(string check)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        if (regex.IsMatch(check) == true)
            return true;
        return false;
    }

    public bool isEmail(string check)
    {
        Regex regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$");
        if (regex.IsMatch(check) == true)
            return true;
        return false;
    }

    public string GetRandomNumbers(int numChars)
    {
        string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S",
                        "T", "U", "V", "W", "X", "Y", "Z","0","1", "2", "3", "4", "5", "6", "7", "8", "9" };

        Random rnd = new Random();
        string random = string.Empty;
        for (int i = 0; i < numChars; i++)
        {
            random += chars[rnd.Next(0, 33)];
        }
        return random;
    }


    /// <summary>
    /// ("Nguyễn Văn A") -> Nguyen Van A
    /// ("Nguyễn Văn A","_") ->Nguyen_Van_A
    /// </summary>
    public static string RejectMarks(string text = "", string separator = null)
    {
        if (text != null || text != "")
        {
            text = text.ToLower();
            string[] pattern = new string[7];
            pattern[0] = "a|(à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ)";//|A(À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ)";
            pattern[1] = "o|(ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ)";//|O|(Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ)";
            pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";//|E|(É|È|Ẻ|Ẹ|Ẽ|Ê|Ế|Ề|Ể|Ệ|Ễ)";
            pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";//|U|(Ú|Ù|Ủ|Ụ|Ũ|Ư|Ứ|Ừ|Ử|Ự|Ữ)";
            pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";//|I|(Í|Ì|Ỉ|Ị|Ĩ)";
            pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";//|Y|(Ý|Ỳ|Ỷ|Ỵ|Ỹ)";
            pattern[6] = "d|đ";//|D|Đ";
            for (int i = 0; i < pattern.Length; i++)
            {
                char replaceChar = pattern[i][0];
                MatchCollection matchs = Regex.Matches(text, pattern[i]);
                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }

            text = Regex.Replace(text, "^-+|(?<=-)-+|-+$", "");
            if (separator != null)
            {
                text = Regex.Replace(text, " ", separator);
            }
        }

        return text;
    }

}