using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
   public class ThemeControl
{
    public int ThemeControlID { get; set; }

    public string ThemeControlName { get; set; }

    public int? ThemeControlTypeID { get; set; }

    public string ThemeName { get; set; }


        public string ThemecontrolTypeName
        {
            get; set;
        }


        public int? ThemeNo { get; set; }

    public string ForegroundColor { get; set; }

    public string BackgroundColor { get; set; }

    public string ShadowColor { get; set; }

    public bool? status { get; set; }

    public DateTime? entrydate { get; set; }

    public bool? isapplied { get; set; }

}

}
