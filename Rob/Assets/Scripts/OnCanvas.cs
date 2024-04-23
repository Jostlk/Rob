using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCanvas : MonoBehaviour
{
    public GameObject Canvas;
    public Image Button;
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
            Button.fillAmount = 0;
        }

    }
}
