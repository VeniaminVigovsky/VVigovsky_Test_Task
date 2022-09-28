using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIController : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] GameObject _bg, _hp, _frame;

    private bool _isInit;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        if (_hp == null && _hpBar != null) _hp = _hpBar.gameObject;

        _isInit = true;
    }

    public void OnHealthAmountChanged(float healthAmount)
    {
        if (!_isInit) Init();

        if (_hpBar == null) return;

        _hpBar.fillAmount = healthAmount;

        if (healthAmount <= 0.01f)
        {
            DisableBar();
        }
    }

    private void DisableBar()
    {
        _bg.SetActive(false);
        _hp.SetActive(false);
        _frame.SetActive(false);
    }

}
