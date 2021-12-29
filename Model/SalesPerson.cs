using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_Version2.Model
{
    public class SalesPerson : Person
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string ToString()
        {
            return Id + " - " + Name;
        }
    }
}
