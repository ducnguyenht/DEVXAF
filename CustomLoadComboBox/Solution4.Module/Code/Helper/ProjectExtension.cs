using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public static class ProjectExtension
{
    public static string RemoveDiacritics(this String s)
    {
        String normalizedString = s.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < normalizedString.Length; i++)
        {
            Char c = normalizedString[i];
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }

        return stringBuilder.ToString();
    }

    public static bool checkNullBlank(string str)
    {
        if (str.Trim().Equals("") || str == null)
        {
            return true;
        }
        return false;
    }

    public static bool CheckAlias(string alias)
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
    public static bool isNumber(string check)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        if (regex.IsMatch(check) == true)
            return true;
        return false;
    }

    public static bool isEmail(string check)
    {
        Regex regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$");
        if (regex.IsMatch(check) == true)
            return true;
        return false;
    }

    //public bool isImage(HtmlInputFile fileUpload)
    //{
    //    Regex imageFilenameRegex = new Regex(@"(.*?)\.(jpg|jpeg|png|gif)$");
    //    if (imageFilenameRegex.IsMatch(Path.GetFileName(fileUpload.PostedFile.FileName)))
    //    {
    //        if (fileUpload.PostedFile.ContentLength > 10048576)
    //            return false;
    //        return true;
    //    }
    //    return false;
    //}

    public static string GetRandomNumbers(int numChars)
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



    public static string RejectMarks(string text)
    {
        string[] pattern = new string[7];
        pattern[0] = "a|(à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ)";
        pattern[1] = "o|(ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ)";
        pattern[2] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";
        pattern[3] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";
        pattern[4] = "i|(í|ì|ỉ|ị|ĩ)";
        pattern[5] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";
        pattern[6] = "d|đ";
        for (int i = 0; i < pattern.Length; i++)
        {
            char replaceChar = pattern[i][0];
            MatchCollection matchs = Regex.Matches(text, pattern[i]);
            foreach (Match m in matchs)
            {
                text = text.Replace(m.Value[0], replaceChar);
            }
        }
        //string str1 = "/!|@|%|\\^|\\*|\\(|\\)|\\+|\\=|\\<|\\>|\\?|\\/|,|\\.|\\:|\\;|\'| |\"|\\&|\\#|\\[|\\]|~|$|_/g";
        //Match matchs1 = Regex.Match(text, str1);
        //text = text.Replace(matchs1.Value, "-");
        text = Regex.Replace(text, "^-+|(?<=-)-+|-+$", "");
        return text;
    }
}

