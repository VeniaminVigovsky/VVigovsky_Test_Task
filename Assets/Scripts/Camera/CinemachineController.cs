using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CinemachineController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCinemachine, _fightCinemachine;

    public void SwitchToMain()
    {
        if (_mainCinemachine == null || _fightCinemachine == null) return;

        _mainCinemachine.gameObject.SetActive(true);
        _fightCinemachine.gameObject.SetActive(false);
    }

    public void SwitchToFight()
    {
        if (_mainCinemachine == null || _fightCinemachine == null) return;

        _fightCinemachine.gameObject.SetActive(true);
        _mainCinemachine.gameObject.SetActive(false);
    }

}
