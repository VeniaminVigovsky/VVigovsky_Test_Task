using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameStateController _gameStateController;
    [SerializeField] private GameState _state;
    public void OnPointerClick(PointerEventData eventData)
    {
        _gameStateController?.ChangeState(_state);
        gameObject.SetActive(false);
    }
}
