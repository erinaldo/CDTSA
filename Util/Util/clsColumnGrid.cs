using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class clsColumnGrid
    {
        public String Name { get; set; }
        public String Caption { get; set; }
        public bool Visible { get; set; }
        public clsColumnGrid()
        {
            Name = "";
            Caption = "";
            Visible = true;
        }
    }

    
}
