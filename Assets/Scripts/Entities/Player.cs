using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractEntity
{
    private MoveToWaypointState _moveState;
    private AttackState _attackState;
    private IdleState _idleState;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        var weaponController = GetComponent<WeaponController>();
        var enemyController = GetComponent<EnemyController>();
        _attackState = new AttackState(weaponController, enemyController);
        var waypointController = GetComponent<WaypointMovementController>();
        _moveState = new MoveToWaypointState(waypointController);
        _idleState = new IdleState();

        _stateMachine.AddTransition(_moveState, _attackState, 
            () => waypointController.IsWaypointReached);
        _stateMachine.AddTransition(_attackState, _moveState,
           () => enemyController.AllEnemiesDead() &&
           waypointController.HasWaypointsLeft());
        _stateMachine.AddTransition(_attackState, _idleState,
            () => enemyController.AllEnemiesDead() &&
            !waypointController.HasWaypointsLeft());
       
        
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
