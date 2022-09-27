using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : IState
{
    private GameStateController _gameStateController;
    private GameState _state;

    public EndGameState(GameStateController gameStateController, GameState state)
    {
        _gameStateController = gameStateController;
        _state = state;
    }

    public void EnterState()
    {
        _gameStateController?.ChangeState(_state);
    }

    public void ExitState()
    {

    }

    public void Tick()
    {
        
    }
}
