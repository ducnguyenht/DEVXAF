using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class ImageHelper
{
    public static string ToThumb(string s)
    {
        return s.Substring(0, s.LastIndexOf('.')) + "_thumb" + s.Substring(s.LastIndexOf('.'));
    }

    public static Image ScaleImage(Image image, int maxHeight)
    {
        var ratio = (double)maxHeight / image.Height;

        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);

        var newImage = new Bitmap(newWidth, newHeight);
        using (var g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, 0, 0, newWidth, newHeight);
        }
        return newImage;
    }
}

