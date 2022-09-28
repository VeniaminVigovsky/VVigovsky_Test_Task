using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    private Rigidbody _rb;
    private bool _isInit;

    private float _lifeTime = 3f;
    private float _timeAlive;

    private int _damage;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _timeAlive = 0;
    }

    private void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive > _lifeTime)
        {
            DisableBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null) damagable.Damage(_damage);

        gameObject.SetActive(false);
    }

    private void Init()
    {
        if (_isInit) return;

        _rb = GetComponent<Rigidbody>();

        _isInit = true;
    }

    public void Shoot(float speed, int damage)
    {
        if (!_isInit) Init();
        _damage = damage;
        _rb.velocity = transform.forward * speed;
    }

    private void DisableBullet()
    {
        if (!_isInit) Init();

        _rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        gameObject.SetActive(false);
    }
}
