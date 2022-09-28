using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent<float> _healthAmountChanged;
    private int _currentHealth;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        _currentHealth = _maxHealth;

        _isInit = true;
    }
    public void Damage(int damage)
    {
        if (!_isInit) Init();

        _currentHealth -= damage;

        _healthAmountChanged?.Invoke((float)_currentHealth / _maxHealth);
    }
}
