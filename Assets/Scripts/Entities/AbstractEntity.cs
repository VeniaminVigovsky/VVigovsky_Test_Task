using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEntity : MonoBehaviour
{
    protected StateMachine _stateMachine;
    protected bool _isInit;

    public virtual void Awake()
    {
        Init();
    }

    public abstract void Init();

    public virtual void Update()
    {
        _stateMachine?.Tick();
    }

}
