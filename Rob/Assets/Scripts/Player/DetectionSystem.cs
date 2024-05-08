using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectionSystem : MonoBehaviour
{
    public Image eyeIcon;
    public float detectionRate;
    public TextMeshProUGUI detectedSign;
    public AudioSource MinAnxious;
    public AudioSource MaxAnxious;

    [HideInInspector]
    public float detectionLevel;
    public InterfaceManager interfaceManager;

    public void WhileNoticed()
    {
        eyeIcon.fillAmount += detectionRate * Time.deltaTime;
    }
    public void WhileNotNoticed()
    {
        eyeIcon.fillAmount -= detectionRate * Time.deltaTime;
    }

    void Update()
    {
        detectionLevel = eyeIcon.fillAmount;
        if (detectionLevel == 0)
        {
            MinAnxious.Stop();
            MaxAnxious.Stop();
        }
        else if (detectionLevel < 0.5f)
        {
            if (!MinAnxious.isPlaying)
            {
                MinAnxious.Play();
                MaxAnxious.Stop();
            }
        }
        else
        {
            if (!MaxAnxious.isPlaying)
            {
                MinAnxious.Stop();
                MaxAnxious.Play();
            }
        }
        //Уровень обнаружения (detectionLevel) идет от 0 до 1, где 0 - полностью скрыт, 1 - обнаружен
        if (detectionLevel >= 1)
        {
            detectedSign.gameObject.SetActive(true);
            interfaceManager.GameOver();
        }
        else
        {
            detectedSign.gameObject.SetActive(false);
        }

    }
}
