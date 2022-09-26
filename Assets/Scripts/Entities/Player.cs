using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractEntity
{
    private IState _moveState;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        var waypointController = GetComponent<WaypointMovementController>();
        _moveState = new MoveToWaypointState(waypointController);        
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            if (_moveState != null && _stateMachine != null)
                _stateMachine.ChangeState(_moveState); 
        }
    }

}
