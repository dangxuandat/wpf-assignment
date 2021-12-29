using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_Version2.Model
{
    public abstract class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
