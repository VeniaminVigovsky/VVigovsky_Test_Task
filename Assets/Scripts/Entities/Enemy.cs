using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstractEntity, IDamagable
{
    public void Damage()
    {
        gameObject.SetActive(false);
    }
}
