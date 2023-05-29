using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_LinQ
{
    internal class Ladder
    {
        public string Harbinger;
        public string SSFHarbinger;
        public string HCHarbinger;
        public string HCSSFHarbinger;
        public List<string> Ladders;

        public Ladder()
        {
            Harbinger = "Harbinger";
            SSFHarbinger = "SSF Harbinger";
            HCHarbinger = "Hardcore Harbinger";
            HCSSFHarbinger = "SSF Harbinger HC";
            Ladders = new List<string> { Harbinger, SSFHarbinger, HCHarbinger, HCSSFHarbinger };
        }
    }
}
