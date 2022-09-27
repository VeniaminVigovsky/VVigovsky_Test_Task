using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateCanvas : MonoBehaviour, IGameStateProcessor
{
    public GameStateEventMediator GameStateEventMediator => _gameStateEventMediator;
    [SerializeField] private TapPanel _startPanel, _restartPanel;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameStateEventMediator _gameStateEventMediator;

    private Dictionary<GameState, List<Action<GameState>>> _gameStateActions;
    private Dictionary<GameState, TapPanel> _panels;

    private void Awake()
    {
        _gameStateActions = new Dictionary<GameState, List<Action<GameState>>>();

        _gameStateActions[GameState.LevelEnd] = new List<Action<GameState>>();
        _gameStateActions[GameState.LevelEnd].Add(OpenTapPanel);

        _gameStateActions[GameState.LevelRestart] = new List<Action<GameState>>();
        _gameStateActions[GameState.LevelRestart].Add(CloseTapPanels);
        _gameStateActions[GameState.LevelRestart].Add(OpenLoadingScreen);

        _gameStateActions[GameState.LevelLoaded] = new List<Action<GameState>>();
        _gameStateActions[GameState.LevelLoaded].Add(OpenLoadingScreen);
        _gameStateActions[GameState.LevelLoaded].Add(OpenTapPanel);

        _panels = new Dictionary<GameState, TapPanel>();
        _panels[GameState.LevelEnd] = _restartPanel;
        _panels[GameState.LevelLoaded] = _startPanel;

        _gameStateEventMediator.GameStateChanged += ProcessGameState;
    }

    private void OnDestroy()
    {
        _gameStateEventMediator.GameStateChanged -= ProcessGameState; 
    }

    public void ProcessGameState(GameState gameState)
    {
        if (_gameStateActions == null) return;
        if (_gameStateActions.TryGetValue(gameState, out var actionList))
        {
            if (actionList != null)
            {
                foreach (var action in actionList)
                {
                    action(gameState);
                }
            }
            
        }
    }

    private void OpenTapPanel(GameState gameState)
    {
        if (_panels == null) return;
        if (_panels.TryGetValue(gameState, out TapPanel panel))
        {
            panel.gameObject.SetActive(true);
        }
    }

    private void CloseTapPanels(GameState gameState)
    {
        _startPanel.gameObject.SetActive(false);
        _restartPanel.gameObject.SetActive(false);
    }

    private void OpenLoadingScreen(GameState gameState)
    {
        if (gameState == GameState.LevelRestart)
        {
            _loadingScreen.gameObject.SetActive(true);
        }
        else if (gameState == GameState.LevelLoaded)
        {
            _loadingScreen.gameObject.SetActive(false);
        }
    }
}
