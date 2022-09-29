using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour, IInputReceiver
{
    public bool IsEnabled
    {
        set => _isEnabled = value;
    }

    public InputEventMediator InputEventMediator => _inputEventMediator;
    [SerializeField] private InputEventMediator _inputEventMediator;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 100;
    [SerializeField] private int _bulletDamage = 10;
    private ObjectPool<Bullet> _bulletPool;
    private Camera _camera;
    private bool _isInit;

    private bool _isEnabled;

    private void Awake()
    {
        Init();
    }

    private void OnDestroy()
    {
        if (_inputEventMediator != null)
            _inputEventMediator.InputReceived -= OnInputReceived;
    }

    public void OnInputReceived(Vector3 touchPos)
    {
        if (!_isInit) Init();

        if (!_isEnabled) return;

        var bullet = _bulletPool.GetFromPool();

        
        touchPos.z = 4;
        var bulletPos = _camera.ScreenToWorldPoint(touchPos);
        bullet.transform.position = bulletPos;
        Ray ray = _camera.ScreenPointToRay(touchPos);
        var rayPoint = ray.GetPoint(100);
        bullet.transform.LookAt(rayPoint);

        bullet?.Shoot(_bulletSpeed, _bulletDamage);
    }

    private void Init()
    {
        if (_isInit) return;

        if (_bulletPrefab != null)
        {
            _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, 5, transform);
        }

        if (_inputEventMediator != null)
            _inputEventMediator.InputReceived += OnInputReceived;

        _camera = Camera.main;
        IsEnabled = false;
        _isInit = true;
    }
}
