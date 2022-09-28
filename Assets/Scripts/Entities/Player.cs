using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractEntity, IGameStateProcessor
{
    public GameStateEventMediator GameStateEventMediator => _gameStateEventMediator;
    [SerializeField] GameStateEventMediator _gameStateEventMediator;
    private MoveToWaypointState _moveState;
    private AttackState _attackState;    
    private EndGameState _winState;


    public override void Init()
    {
        if (_isInit) return;
        _stateMachine = new StateMachine();
        var weaponController = GetComponent<WeaponController>();
        var enemyController = GetComponent<EnemyController>();
        var cinemachineController = GetComponent<CinemachineController>();
        _attackState = new AttackState(weaponController, enemyController, cinemachineController);
        var waypointController = GetComponent<WaypointMovementController>();
        _moveState = new MoveToWaypointState(waypointController);
        var gameStateController = GetComponent<GameStateController>();
        _winState = new EndGameState(gameStateController, GameState.LevelEnd);

        _stateMachine.AddTransition(_moveState, _attackState,
            () => waypointController.IsWaypointReached);
        _stateMachine.AddTransition(_attackState, _moveState,
           () => enemyController.AllEnemiesDead() &&
           waypointController.HasWaypointsLeft());
        _stateMachine.AddTransition(_attackState, _winState,
            () => enemyController.AllEnemiesDead() &&
            !waypointController.HasWaypointsLeft());

        if (_gameStateEventMediator != null)
            _gameStateEventMediator.GameStateChanged += ProcessGameState;

        _isInit = true;

    }

    private void OnDestroy()
    {
        if (_gameStateEventMediator != null)
            _gameStateEventMediator.GameStateChanged -= ProcessGameState;
    }

    public override void Update()
    {
        base.Update();
    }

    public void ProcessGameState(GameState gameState)
    {
        if (gameState != GameState.LevelStart) return;

        if (_stateMachine != null && _moveState != null)
            _stateMachine.ChangeState(_moveState);
    }
}
