using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEntity : MonoBehaviour
{
    protected StateMachine _stateMachine;

    public virtual void Update()
    {
        _stateMachine?.Tick();
    }

}
