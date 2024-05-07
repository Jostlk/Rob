using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public int MoneyAmount = 10000;
    public float Timer;
    public Image Button;
    public TextMeshProUGUI UICounter;
    public TextMeshProUGUI TabUICounter;
    public CanvasManager canvasManager;
    public InterfaceManager interfaceManager;
    public GameObject Cash;
    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            Button.fillAmount += Timer * Time.deltaTime;
            if (Button.fillAmount == 1)
            {
                MoneyAmount += Convert.ToInt32(UICounter.text);
                canvasManager.Timer = 0;
                UICounter.gameObject.SetActive(true);
                UICounter.text = MoneyAmount.ToString();
                TabUICounter.text = MoneyAmount.ToString();
                Destroy(Cash);
            }
        }
        else
        {
            Button.fillAmount -= 2.5f * Time.deltaTime;
        }
        if(Convert.ToInt32(UICounter.text) == 216000)
        {
            interfaceManager.Win();
        }
    }
}
