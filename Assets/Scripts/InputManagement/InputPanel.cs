using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private InputEventMediator _inputMediator;

    public void OnPointerClick(PointerEventData eventData)
    {
        _inputMediator?.OnInputReceived();
    }
}
