using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotateController : MonoBehaviour
{
    private Transform _cameraTransform;

    private Transform _transform;
    
    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        LookAtCamera();
    }

    private void Init()
    {
        if (_isInit) return;

        _transform = transform;

        _isInit = true;
    }

    private void LookAtCamera()
    {
        if (_cameraTransform == null) return;

        if (!_isInit) Init();

        _transform.LookAt(_cameraTransform);
    }

    public void OnCameraFound(Camera camera)
    {
        _cameraTransform = camera.transform;
    }


}
