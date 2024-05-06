using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    public TextMeshProUGUI UIObjective;
    public TextMeshProUGUI UITabObjective;
    public TextMeshProUGUI DescText;
    private bool _isOnTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            if (name == "Trigger")
            {
                if (!_isOnTrigger)
                {
                    UIObjective.text = "Отключить камеры";
                    UITabObjective.text = "Отключить камеры";
                    UITabObjective.fontSize = 41;
                    DescText.text = "Нужно найти комнату управления камерами и отключить их";
                    _isOnTrigger = true;
                    Destroy(gameObject);
                }
                else
                {
                    TriggerOffCamera();
                }

            }
        }
    }
    public void TriggerOffCamera()
    {
        if (!_isOnTrigger)
        {
            _isOnTrigger = true;
        }
        else
        {
            UIObjective.text = "Взломать хранилище";
            UIObjective.fontSize = 38;
            UITabObjective.text = "Взломать хранилище";
            UITabObjective.fontSize = 37;
            DescText.text = "Нужно взломать дверь хранилища и ограбить его";
        }

    }
}
