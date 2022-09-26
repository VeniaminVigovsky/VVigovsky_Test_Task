using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState _currentState;
    public void ChangeState(IState newState)
    {
        if (newState == _currentState) return;
        _currentState?.ExitState();
        _currentState = newState;
        _currentState?.EnterState();
    }

    public void Tick()
    {
        _currentState?.Tick(); 
    }
    
}