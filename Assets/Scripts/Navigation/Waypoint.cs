using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public EnemyController EnemyController { get; private set; }

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        EnemyController = GetComponent<EnemyController>();

        _isInit = true;
    }
}
