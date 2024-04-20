using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMoney : MonoBehaviour
{
    public GameObject Canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Capsule")
        {
            Canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Capsule")
        {
            Canvas.SetActive(false);
        }

    }
}
