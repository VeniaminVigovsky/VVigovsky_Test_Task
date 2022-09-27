using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateProcessor
{
    GameStateEventMediator GameStateEventMediator { get; }
    void ProcessGameState(GameState gameState);
}


