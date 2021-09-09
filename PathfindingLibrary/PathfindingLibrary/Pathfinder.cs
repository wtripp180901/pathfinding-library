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
            List<PFNode> openList = BakeMesh();
            return null;
        }

        private List<PFNode> BakeMesh()
        {
            List<PFNode> pFNodes = new List<PFNode>();
            T[] objects = rawMesh.allObjects;
            
            for(int i = 0;i < objects.Length; i++)
            {
                PFNode newNode = rawMesh.NodeFromObject(objects[i]);
                objToNodeMap.Add(objects[i], newNode);
                pFNodes.Add(newNode);
            }

            for(int i = 0;i < objects.Length; i++)
            {
                PFNode currentNode;
                T currentObject = objects[i];
                objToNodeMap.TryGetValue(currentObject, out currentNode);
                T[] incidentObjects = rawMesh.GetIncidentObjects(currentObject);
                for(int j = 0;j < incidentObjects.Length; j++)
                {
                    PFNode currentIncidentNode;
                    if(objToNodeMap.TryGetValue(incidentObjects[j],out currentIncidentNode))
                    {
                        currentNode.AddIncidentNode(currentIncidentNode);
                    }
                    else
                    {
                        throw new Exception("Object from GetIncidentObjects not contain in allObjects");
                    }
                }
            }

            return pFNodes;
        }
    }
}
