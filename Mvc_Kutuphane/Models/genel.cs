using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class genel
    {
        public static string ToTitleCase(string Text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text);
        }
    }
}