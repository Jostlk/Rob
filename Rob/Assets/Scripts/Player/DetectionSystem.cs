using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionSystem : MonoBehaviour
{
    public Image eyeIcon;
    public float detectionRate;

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
    }
}
