using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public Light _Flashlight;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _Flashlight.enabled = !_Flashlight.enabled;
        }
    }
}
