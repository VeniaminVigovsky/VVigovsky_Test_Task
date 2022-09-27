using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameStateEventMediator", menuName ="GameState/GameStateEventMediator")]
public class GameStateEventMediator : ScriptableObject
{
    public event Action<GameState> GameStateChanged;

    public void OnGameStateChanged(GameState gameState)
    {
        GameStateChanged?.Invoke(gameState);
    }
}
