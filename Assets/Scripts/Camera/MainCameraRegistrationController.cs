using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRegistrationController : MonoBehaviour
{
    public static Camera MAINCAMERA;

    private void Awake()
    {
        MAINCAMERA = GetComponent<Camera>();
    }

}
