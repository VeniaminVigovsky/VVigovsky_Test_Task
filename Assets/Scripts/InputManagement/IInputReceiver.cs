using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputReceiver
{
    InputEventMediator InputEventMediator { get; }
    void OnInputReceived();

}
