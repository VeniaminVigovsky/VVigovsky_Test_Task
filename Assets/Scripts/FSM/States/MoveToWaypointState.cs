using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypointState : IState
{  
    private WaypointMovementController _waypointMovementController;
    public MoveToWaypointState(WaypointMovementController waypointMovementController)
    {        
        _waypointMovementController = waypointMovementController;
    }

    public void EnterState()
    {
        _waypointMovementController?.MoveToNextPoint();
    }

    public void ExitState()
    {

    }

    public void Tick()
    {
        _waypointMovementController?.CheckPosition();
    }
}
