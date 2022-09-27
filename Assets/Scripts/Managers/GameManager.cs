using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour, IGameStateProcessor
{
    public GameStateEventMediator GameStateEventMediator => _gameStateEventMediator;

    [SerializeField] private GameStateEventMediator _gameStateEventMediator;
    [SerializeField] private Camera _camera;
    
    private GameStateController _gameStateController;

    private Dictionary<GameState, Action> _gameStateActions;

    private SceneLoader _sceneLoader;

    private bool _isInit;

    private void Awake()
    {
        Init();
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

    private void RestartGame()
    {
        if (_sceneLoader == null) return;


        _sceneLoader.UnloadCurrenLevelScene();
        _camera.gameObject.SetActive(true);
        Invoke("Foo", 2.0f);
        
    }

    private void Foo()
    {
        _sceneLoader.LoadLevel(1);
        _camera.gameObject.SetActive(false);
        _gameStateController.ChangeState(GameState.LevelLoaded);
    }
}
