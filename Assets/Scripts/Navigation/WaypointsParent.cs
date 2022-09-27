using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsParent : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;

    public Queue<Waypoint> GetWaypointQueue()
    {
        
        if (_waypoints == null) return null;

        var queue = new Queue<Waypoint>();
        foreach (var waypoint in _waypoints)
        {
            queue.Enqueue(waypoint);
        }

        return queue;

    }
}
