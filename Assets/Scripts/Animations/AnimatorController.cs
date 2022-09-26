using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Animator _animator;
    private const string _speedParameterName = "Speed";

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        SetSpeed();
    }

    private void Init()
    {
        if (_isInit) return;
        _animator = GetComponent<Animator>();
        _isInit = true;
    }

    public void SetSpeed()
    {
        Init();
        if (_animator == null || _agent == null) return;
        float speed = _agent.velocity.magnitude;
        _animator.SetFloat(_speedParameterName, speed);
    }
}
