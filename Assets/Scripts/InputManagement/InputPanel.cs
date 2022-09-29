using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private InputEventMediator _inputMediator;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 inputPos = new Vector3(0.0f, 0.0f, 0.0f);   

#if UNITY_EDITOR
        inputPos = Input.mousePosition;
#else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            inputPos = touch.position;
        }
#endif

        _inputMediator?.OnInputReceived(inputPos);
    }
}
