using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour, IGameStateProcessor
{
    public GameStateEventMediator GameStateEventMediator => _gameStateEventMediator;

    [SerializeField] private GameStateEventMediator _gameStateEventMediator;
    
    private GameStateController _gameStateController;

    private Dictionary<GameState, Action> _gameStateActions;

    private SceneLoader _sceneLoader;

    private int _currentLevelNumber = 1;

    private bool _isInit;

    private void Awake()
    {
        Init();
        StartGame();
    }

    private void OnDestroy()
    {
        _gameStateEventMediator.GameStateChanged -= ProcessGameState;
    }

    private void Init()
    {
        if (_isInit) return;

        _sceneLoader = GetComponent<SceneLoader>();

        _gameStateController = GetComponent<GameStateController>();

        _gameStateActions = new Dictionary<GameState, Action>();

        _gameStateActions[GameState.LevelRestart] = RestartGame;

        _gameStateEventMediator.GameStateChanged += ProcessGameState;        

        _isInit = true;
    }

    public void ProcessGameState(GameState gameState)
    {
        if (!_isInit) Init();

        if (_gameStateActions == null) return;

        if (_gameStateActions.TryGetValue(gameState, out Action action))
        {
            action();
        }
    }

    private void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        _sceneLoader.LoadUIScene();
        while (_sceneLoader.IsBusy)
        {
            yield return null;
        }
        LoadLevel();
    }

    private void RestartGame()
    {
        if (_sceneLoader == null) return;

        StartCoroutine(RestartLevelCoroutine());        
    }

    private IEnumerator RestartLevelCoroutine()
    {
        _sceneLoader.UnloadCurrenLevelScene();
        while (_sceneLoader.IsBusy)
        {
            yield return null;
        }
        LoadLevel();
    }

    private void LoadLevel()
    {
        StartCoroutine(LoadLevelCoroutine());
    }

    private IEnumerator LoadLevelCoroutine()
    {
        _sceneLoader.LoadLevel(_currentLevelNumber);
        while (_sceneLoader.IsBusy)
        {
            yield return null;
        }
        _gameStateController.ChangeState(GameState.LevelLoaded);
    }
}
