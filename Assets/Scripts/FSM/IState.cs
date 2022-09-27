using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IState
{       
    void EnterState();
    void ExitState();
    void Tick();
}

