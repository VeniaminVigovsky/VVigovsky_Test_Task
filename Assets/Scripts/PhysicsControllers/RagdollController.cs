using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{    
    [SerializeField] private Collider _entityCollider;
    [SerializeField] private Animator _animator;

    public void EnableRagdoll(bool enabled)
    {
        _entityCollider.enabled = !enabled;
        _animator.enabled = !enabled;
    }
}
