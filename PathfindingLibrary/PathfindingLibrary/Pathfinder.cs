using System;
using System.Collections.Generic;

namespace PathfindingLibrary
{
    public class Pathfinder<T>
    {
        INavMesh<T> rawMesh;
        Dictionary<T, PFNode> objToNodeMap = new Dictionary<T, PFNode>();
        Coordinates targetCoords;

        public Pathfinder(INavMesh<T> mesh)
        {
            rawMesh = mesh;
        }

        public Queue<T> GetPath(T from,T to)
        {
            targetCoords = rawMesh.NodeFromObject(to).coords;
            PFNode initialNode = CreateNode(from);
            List<PFNode> closedList = new List<PFNode>() { initialNode };
            List<PFNode> openList = new List<PFNode>();
            openList.AddRange(ComputeIncidentNodes(initialNode,openList,closedList));
            PFNode currentNode = initialNode;
            int killswitch = 10000;
            bool foundFinalTile = false;
            while(!foundFinalTile && killswitch > 0)
            {
                killswitch -= 1;
                openList.Sort(comparisonFunction);
                currentNode = openList[openList.Count - 1];
                if (currentNode.source.Equals(to))
                {
                    foundFinalTile = true;
                }
                else
                {
                    openList.RemoveAt(openList.Count - 1);
                    closedList.Add(currentNode);
                    openList.AddRange(ComputeIncidentNodes(currentNode, openList, closedList));
                }
            }
            return null;
        }

        private static int comparisonFunction(PFNode x,PFNode y)
        {
            if (x.f < y.f) return 1;
            else if (x.f == y.f) return 0;
            else return -1;
        }

        private PFNode[] ComputeIncidentNodes(PFNode sourceNode,List<PFNode> openList,List<PFNode> closedList)
        {
            T[] incidentObjects = rawMesh.GetIncidentObjects((T)sourceNode.source);
            List<PFNode> incidents = new List<PFNode>();
            for(int i = 0;i < incidentObjects.Length; i++)
            {
                PFNode newNode = CreateNode(incidentObjects[i],sourceNode);
                bool inExistingList = false;
                for(int j = 0;j < openList.Count; j++)
                {
                    if (openList[j].source.Equals(newNode.source))
                    {
                        inExistingList = true;
                        if (openList[j].f <= newNode.f) openList[j] = newNode;
                        break;
                    }
                }
                for(int j = 0;j < closedList.Count; j++)
                {
                    if (openList[j].source.Equals(newNode.source))
                    {
                        inExistingList = true;
                        break;
                    }
                }
                if(!inExistingList) incidents.Add(newNode);
            }
            return incidents.ToArray();
        }

        private PFNode CreateNode(T source,PFNode parent)
        {
            return CreateNode(source).parent = parent;
        }

        private PFNode CreateNode(T source)
        {
            PFNode newNode = rawMesh.NodeFromObject(source);
            newNode.SetH(targetCoords);
            return newNode;
        }
    }
}
