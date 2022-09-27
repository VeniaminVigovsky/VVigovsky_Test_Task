using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapToStartPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameStateController _gameStateController;

    public void OnPointerClick(PointerEventData eventData)
    {
        _gameStateController?.ChangeState(GameState.LevelStart);
        gameObject.SetActive(false);
    }

}
