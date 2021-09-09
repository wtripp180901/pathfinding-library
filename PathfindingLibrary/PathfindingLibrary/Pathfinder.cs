using System;
using System.Collections.Generic;

namespace PathfindingLibrary
{
    public class Pathfinder<T>
    {
        INavMesh<T> rawMesh;

        public Pathfinder(INavMesh<T> mesh)
        {
            rawMesh = mesh;
        }

        public Queue<T> getPath(T from,T to)
        {
            return null;
        }

        private List<PFNode> bakeMesh()
        {
            T[] objects = rawMesh.allObjects;
            Dictionary<T, PFNode> convertedTo = new Dictionary<T, PFNode>();
            List<PFNode> pFNodes = new List<PFNode>();
            for(int i = 0;i < objects.Length; i++)
            {
                PFNode newNode = rawMesh.NodeFromObject(objects[i]);
                convertedTo.Add(objects[i], newNode);
                pFNodes.Add(newNode);
            }

            for(int i = 0;i < objects.Length; i++)
            {
                PFNode currentNode;
                T currentObject = objects[i];
                convertedTo.TryGetValue(currentObject, out currentNode);
                T[] incidentObjects = rawMesh.GetIncidentObjects(currentObject);
                for(int j = 0;j < incidentObjects.Length; j++)
                {
                    PFNode currentIncidentNode;
                    if(convertedTo.TryGetValue(incidentObjects[j],out currentIncidentNode))
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
