using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="InputEventMediator", menuName ="Input Management/InputEventMediator")]
public class InputEventMediator : ScriptableObject
{
    public event Action<Vector3> InputReceived;

    public void OnInputReceived(Vector3 inputPos)
    {
        InputReceived?.Invoke(inputPos);
    }
}
