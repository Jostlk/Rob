using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    static public string WinBalance = "216000";
    public GameObject MoneyCounterObject;
    public GameObject Bombs;
    public float Timer = 0;
    public TextMeshProUGUI Balance;
    private bool IsDestroing = false;
    void Update()
    {
        if (MoneyCounterObject.activeSelf == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 5)
            {
                MoneyCounterObject.SetActive(false);
            }

        }
        if (Balance.text == WinBalance && IsDestroing == false)
        {
            Bombs.SetActive(true);
            IsDestroing = true;
        }
    }
}
