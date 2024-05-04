using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOFF : MonoBehaviour
{
    public Image Camera;
    public Material CameraMaterial;
    public Image CameraUpperLayer;
    public List<CameraDetection> CameraSystems;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (Input.GetKey(KeyCode.E))
            {
                CameraUpperLayer.fillAmount += 0.1f * Time.deltaTime;
                if (CameraUpperLayer.fillAmount == 1)
                {
                    for (int i = 0; i < CameraSystems.Count; i++)
                    {
                        CameraSystems[i].enabled = false;
                    }
                    Destroy(gameObject);
                }
            }
            else
            {
                CameraUpperLayer.fillAmount = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Capsule")
        {
            CameraUpperLayer.fillAmount = 0;
        }
    }
}
