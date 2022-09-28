using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{       
    
    [SerializeField] private float _checkRadius = 10.0f;

    private List<Enemy> _enemies = new List<Enemy>();

    public void FindEnemies()
    {       

        Collider[] colliders = Physics.OverlapSphere(transform.position, _checkRadius);
        if (colliders != null)
        {
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<Enemy>(out var enemy))
                {
                    _enemies.Add(enemy);
                }
            }            
        }
    }

    public bool AllEnemiesDead()
    { 
        foreach (var enemy in _enemies)
        {
            if (!enemy.IsDead) return false;
        }
        _enemies.Clear();
        return true;

    }


#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _checkRadius);
    }
#endif
}
