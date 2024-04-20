using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject MoneyCounter;
    public float Timer = 0;
    void Update()
    {
        if (MoneyCounter.activeSelf == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 5)
            {
                MoneyCounter.SetActive(false);
            }

        }
    }
}
