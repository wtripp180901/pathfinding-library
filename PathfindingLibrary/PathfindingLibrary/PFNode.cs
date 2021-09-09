using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingLibrary
{
    public class PFNode
    {
        private int g;
        private int h;
        private List<PFNode> incidentNodes;

        public PFNode(int cost)
        {

        }

        public void AddIncidentNode(PFNode node) { incidentNodes.Add(node); }
    }
}
