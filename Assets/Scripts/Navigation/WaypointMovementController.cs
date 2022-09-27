using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointMovementController : MonoBehaviour 
{
    public bool IsWaypointReached { get; private set; }

    [SerializeField] private Waypoint[] _waypoints;
    private NavMeshAgent _agent;
    private Queue<Waypoint> _waypointsQueue;
    private Waypoint _currentWaypoint;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit == true) return;

        _agent = GetComponent<NavMeshAgent>();
        _waypointsQueue = new Queue<Waypoint>();
        if (_waypoints != null)
        {
            foreach (var wayPoint in _waypoints)
            {
                _waypointsQueue.Enqueue(wayPoint);
            }
        }

        if (_agent != null) _agent.isStopped = true;

        _isInit = true;
    }

    public void MoveToNextPoint()
    {
        Init();
        if (_agent == null) return;
        if (_waypointsQueue.Count > 0)
        {
            _currentWaypoint = _waypointsQueue.Dequeue();
            _agent.isStopped = false;
            IsWaypointReached = false;
            _agent.SetDestination(_currentWaypoint.transform.position);
        }
    }

    public void CheckPosition()
    {
        Init();
        if (_agent == null || _agent.isStopped || _currentWaypoint == null) return;
        var position = _currentWaypoint.transform.position;
        if (Vector3.Distance(_agent.transform.position, position) < 0.1f)
        {
            Stop();
        }
    }

    public bool HasWaypointsLeft()
    {
        if (_waypointsQueue == null) return false;
        else return _waypointsQueue.Count > 0;
    }

    private void Stop()
    {
        _agent.isStopped = true;
        IsWaypointReached = true;    
    }

   
}
