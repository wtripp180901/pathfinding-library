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
        private readonly Coordinates _coords;
        public Coordinates coords
        {
            get { return coords; }
        }
        private readonly float g;
        private float h = 0;
        public float f { get { return h + g; } }
        //private List<PFNode> incidentNodes;
        public PFNode parent = null;
        public object source;

        public PFNode(float cost,Coordinates coords,object sourceObject)
        {
            _coords = coords;
            g = cost;
            source = sourceObject;
        }

        public void SetH(Coordinates targetCoords)
        {
            float dx = targetCoords.x - _coords.x;
            float dy = targetCoords.y - _coords.y;
            float dz = targetCoords.z - _coords.z;
            h = (dx * dx) + (dy * dy) + (dz * dz);
        }
    }
}
