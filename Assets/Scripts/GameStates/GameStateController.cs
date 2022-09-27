using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private GameStateEventMediator _eventMediator;   

    public void ChangeState(GameState gameState)
    {
        _eventMediator?.OnGameStateChanged(gameState);
    }

}
