using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractEntity
{
    private IState _moveState;
    private IState _attackState;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        var weaponController = GetComponent<WeaponController>();
        _attackState = new AttackState(weaponController);
        var waypointController = GetComponent<WaypointMovementController>();
        _moveState = new MoveToWaypointState(waypointController);
        if (waypointController != null)
        {
            waypointController.WaypointReached += (waypoint) =>
            {
                var enemyController = waypoint.EnemyController;
                if (enemyController != null)
                {
                    if (enemyController.Enemies.Length > 0)
                        enemyController.AllEnemiesDead += () => _stateMachine?.ChangeState(_moveState);
                    else return;
               
                }
                _stateMachine?.ChangeState(_attackState);
            };
        }

        
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
