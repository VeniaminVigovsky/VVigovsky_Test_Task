using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{  
    private WeaponController _weaponController;
    private EnemyController _enemyController;

    private CinemachineController _cinemachineController;
    public AttackState(WeaponController weaponController, EnemyController enemyController, CinemachineController cinemachineController = null)
    {
        _weaponController = weaponController;
        _enemyController = enemyController;

        _cinemachineController = cinemachineController;
    }

    public void EnterState()
    {
        if (_weaponController != null)
            _weaponController.IsEnabled = true;

        _enemyController?.FindEnemies();

        if (!_enemyController.AllEnemiesDead())
        {
            _cinemachineController?.SwitchToFight();
        }
    }

    public void ExitState()
    {
        if (_weaponController != null)
            _weaponController.IsEnabled = false;

        _cinemachineController?.SwitchToMain();
    }

    public void Tick()
    {        
        
    }
    
}
