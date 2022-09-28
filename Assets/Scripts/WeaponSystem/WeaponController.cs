using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public bool IsEnabled
    {
        set => _isEnabled = value;
    }

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
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isEnabled)
        {
            Init();

            var bullet = _bulletPool.GetFromPool();

            var pos = Input.mousePosition;
            pos.z = 4;
            var bulletPos = _camera.ScreenToWorldPoint(pos);
            bullet.transform.position = bulletPos;
            Ray ray = _camera.ScreenPointToRay(pos);
            var rayPoint = ray.GetPoint(100);
            bullet.transform.LookAt(rayPoint); 

            bullet?.Shoot(_bulletSpeed, _bulletDamage);
        }
    }

    private void Init()
    {
        if (_isInit) return;

        if (_bulletPrefab != null)
        {
            _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, 5, transform);
        }

        _camera = Camera.main;
        IsEnabled = false;
        _isInit = true;
    }
}
