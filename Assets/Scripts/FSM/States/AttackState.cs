using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{  
    private WeaponController _weaponController;
    private EnemyController _enemyController;
    public AttackState(WeaponController weaponController, EnemyController enemyController)
    {
        _weaponController = weaponController;
        _enemyController = enemyController;
    }

    public void EnterState()
    {
        if (_weaponController != null)
            _weaponController.IsEnabled = true;

        _enemyController?.FindEnemies();
    }

    public void ExitState()
    {
        if (_weaponController != null)
            _weaponController.IsEnabled = false;
    }

    public void Tick()
    {
        
    }
    
}
