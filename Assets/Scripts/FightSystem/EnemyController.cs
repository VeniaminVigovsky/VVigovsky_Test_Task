using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public event Action AllEnemiesDead;

    public Enemy[] Enemies => _enemies;

    [SerializeField] private Enemy[] _enemies;

    private bool _checkForEnemies = true;

    private void Update()
    {
        if (!_checkForEnemies) return;

        foreach (var enemy in _enemies)
        {
            if (enemy.gameObject.activeInHierarchy) return;
        }

        AllEnemiesDead?.Invoke();
        _checkForEnemies = false;
    }
}
