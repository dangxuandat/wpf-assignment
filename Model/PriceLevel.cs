using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_Version2.Model
{
    public enum PriceLevel
    {
        [Description("1 - Regular Price")]
        Regular_Price,
        [Description("2 - Wholesale Price")]
        Wholesale_Price,
        [Description("3 - Internal Price")]
        Internal_Price
    }
}
