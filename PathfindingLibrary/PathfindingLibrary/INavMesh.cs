using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingLibrary
{
    public interface INavMesh<T>
    {
        T[] GetIncidentObjects(T incidentTo);
        //T[] allObjects { get; }
        PFNode NodeFromObject(T source);
    }
}
