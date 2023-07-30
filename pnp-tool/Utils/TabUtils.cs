using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnp_tool.Utils
{
    public static class TabUtils
    {

        /// <summary>
        /// Generates a unique tab name that is not already in use.
        /// </summary>
        /// <returns>A unique tab name</returns>
        public static string GenerateUniqueTabName(HashSet<string> usedTabNames)
        {
            int suffix = 1;
            string uniqueName;

            do
            {
                uniqueName = $"Tab {suffix}";
                suffix++;
            } while (usedTabNames.Contains(uniqueName));

            usedTabNames.Add(uniqueName);
            return uniqueName;
        }
    }
}
