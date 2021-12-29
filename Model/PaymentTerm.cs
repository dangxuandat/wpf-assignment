using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_Version2.Model
{
    public enum PaymentTerm
    {
        [Description("0 Days")]
        Zero_Days,
        [Description("7 Days")]
        Seven_Days,
        [Description("30 Days")]
        Thirty_Days


    }
}
