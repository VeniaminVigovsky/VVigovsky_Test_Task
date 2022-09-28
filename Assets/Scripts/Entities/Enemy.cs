using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstractEntity
{
    public bool IsDead { get; private set; }
    [SerializeField] private float _timeBeforeDespawn = 1;
    private RagdollController _ragdollController;

    public override void Init()
    {
        if (_isInit) return;

        _ragdollController = GetComponent<RagdollController>();

        _isInit = true;
    }

    public void OnHealthAmountChanged(float healthAmount)
    {
        if (healthAmount <= 0.01f)
        {
            StartCoroutine(DeathCoroutine());
        }
    }

    private IEnumerator DeathCoroutine()
    {
        IsDead = true;
        _ragdollController?.EnableRagdoll(true);
        yield return new WaitForSeconds(_timeBeforeDespawn);
        gameObject.SetActive(false);
    }

}
