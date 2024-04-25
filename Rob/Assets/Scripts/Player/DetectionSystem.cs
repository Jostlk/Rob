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

    [HideInInspector]
    public float detectionLevel;

    //Этот метод вызывается из EnemyAI.cs когда _isNoticed = true
    public void WhileNoticed()
    {
        eyeIcon.fillAmount += detectionRate * Time.deltaTime;
    }

    //То же самое но когда _isNoticed = false
    public void WhileNotNoticed()
    {
        eyeIcon.fillAmount -= detectionRate * Time.deltaTime;
    }
 
    void Update()
    {
        detectionLevel = eyeIcon.fillAmount;
        //Уровень обнаружения (detectionLevel) идет от 0 до 1, где 0 - полностью скрыт, 1 - обнаружен
        if (detectionLevel >= 1)
        {
            detectedSign.gameObject.SetActive(true);
        }
        else
        {
            detectedSign.gameObject.SetActive(false);
        }

    }
}
