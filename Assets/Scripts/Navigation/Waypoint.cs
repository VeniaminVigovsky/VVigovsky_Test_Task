using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject _graphics;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();  
        if (player != null)
            _graphics.SetActive(false);
    }
}
