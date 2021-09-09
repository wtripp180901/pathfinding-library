using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingLibrary
{
    public struct Coordinates
    {
        public float x;
        public float y;
        public float z;

        public Coordinates(float x,float y,float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Coordinates(float x,float y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }
    }

    public class PFNode
    {
        private readonly Coordinates coords;
        private readonly int g;
        private int h;
        //private List<PFNode> incidentNodes;
        public PFNode parent;

        public PFNode(int cost,Coordinates coords)
        {
            this.coords = coords;
            g = cost;
        }

        //public void AddIncidentNode(PFNode node) { incidentNodes.Add(node); }
    }
}
