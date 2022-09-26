using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private WeaponController _weaponController;
    
    public AttackState(WeaponController weaponController)
    {
        _weaponController = weaponController;
    }

    public void EnterState()
    {
        if (_weaponController != null)
            _weaponController.IsEnabled = true;
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
