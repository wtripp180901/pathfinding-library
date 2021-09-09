using System;
using System.Collections.Generic;

namespace PathfindingLibrary
{
    public class Pathfinder<T>
    {
        INavMesh<T> rawMesh;
        Dictionary<T, PFNode> objToNodeMap = new Dictionary<T, PFNode>();

        public Pathfinder(INavMesh<T> mesh)
        {
            rawMesh = mesh;
        }

        public Queue<T> GetPath(T from,T to)
        {
            PFNode initialNode = CreateNode(from);
            List<PFNode> closedList = new List<PFNode>() { initialNode };
            List<PFNode> openList = new List<PFNode>(ComputeIncidentNodes(initialNode,from));
            return null;
        }

        private PFNode[] ComputeIncidentNodes(PFNode sourceNode, T sourceObject)
        {
            T[] incidentObjects = rawMesh.GetIncidentObjects(sourceObject);
            List<PFNode> incidents = new List<PFNode>();
            for(int i = 0;i < incidentObjects.Length; i++)
            {
                PFNode newNode = CreateNode(incidentObjects[i],sourceNode);
                incidents.Add(newNode);
            }
            return incidents.ToArray();
        }

        private PFNode CreateNode(T source)
        {
            PFNode newNode;
            if (!objToNodeMap.TryGetValue(source,out newNode))
            {
                newNode = rawMesh.NodeFromObject(source);
                objToNodeMap.Add(source, newNode);
            }
            return newNode;
        }

        private PFNode CreateNode(T source,PFNode parent)
        {
            return CreateNode(source).parent = parent;
        }
    }
}
