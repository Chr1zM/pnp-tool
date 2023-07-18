using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnp_tool.Model
{
    public class Tab
    {
        private static int Id = 1;
        private static int getNextId() { return Id++; }

        public string TabTitle { get; set; }

        public Tab(string title)
        {
            TabTitle = title;
        }

        public Tab()
        {
            TabTitle = "Tab" + getNextId();
        }
        
    }
}
