using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateCanvas : MonoBehaviour, IGameStateProcessor
{
    public GameStateEventMediator GameStateEventMediator => _gameStateEventMediator;
    [SerializeField] private TapPanel _startPanel, _restartPanel;
    [SerializeField] private GameStateEventMediator _gameStateEventMediator;

    private Dictionary<GameState, TapPanel> _panels;

    private void Awake()
    {
        _panels = new Dictionary<GameState, TapPanel>();
        _panels[GameState.LevelEnd] = _restartPanel;
        _gameStateEventMediator.GameStateChanged += ProcessGameState;
    }

    private void OnDestroy()
    {
        _gameStateEventMediator.GameStateChanged -= ProcessGameState; 
    }

    public void ProcessGameState(GameState gameState)
    {
        if (_panels == null) return;
        if (_panels.TryGetValue(gameState, out TapPanel panel))
        {
            panel.gameObject.SetActive(true);
        }
    }
}
