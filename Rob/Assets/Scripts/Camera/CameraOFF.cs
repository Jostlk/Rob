using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOFF : MonoBehaviour
{
    public Image Camera;
    public Material CameraMaterial;
    public Image CameraUpperLayer;
    public AudioSource KeyboardSource;
    public List<CameraDetection> CameraSystems;
    public ObjectiveManager objectiveManager;
    public GameObject TriggerOffCamerаs;
    public GameObject TriggerRobSafe;
    public SpawnKey spawnKey;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (Input.GetKey(KeyCode.E))
            {
                CameraUpperLayer.fillAmount += 0.1f * Time.deltaTime;
                if (!KeyboardSource.isPlaying)
                {
                    KeyboardSource.Play();
                }
                if (CameraUpperLayer.fillAmount == 1)
                {
                    if (TriggerOffCamerаs != null)
                    {
                        Destroy(TriggerOffCamerаs);
                        TriggerRobSafe.SetActive(true);
                    }
                    else
                    {
                        Destroy(TriggerRobSafe);
                        objectiveManager.SwitchObjectiveTo(2);
                        spawnKey.SpawnKeys();
                    }
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
