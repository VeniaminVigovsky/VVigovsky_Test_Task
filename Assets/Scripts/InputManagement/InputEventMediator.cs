using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="InputEventMediator", menuName ="Input Management/InputEventMediator")]
public class InputEventMediator : ScriptableObject
{
    public event Action InputReceived;

    public void OnInputReceived()
    {
        InputReceived?.Invoke();
    }
}
