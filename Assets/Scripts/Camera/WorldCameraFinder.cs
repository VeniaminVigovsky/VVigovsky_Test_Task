using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldCameraFinder : MonoBehaviour
{
    [SerializeField] private UnityEvent<Camera> _cameraFound;

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;

        StartCoroutine(FindCameraCoroutine());

        _isInit = true;
    }

    private IEnumerator FindCameraCoroutine()
    {
        Canvas canvas = GetComponent<Canvas>();

        if (canvas == null) yield break;

        while (MainCameraRegistrationController.MAINCAMERA == null) yield return null;
        canvas.worldCamera = MainCameraRegistrationController.MAINCAMERA;
        _cameraFound?.Invoke(MainCameraRegistrationController.MAINCAMERA);
    }

}
