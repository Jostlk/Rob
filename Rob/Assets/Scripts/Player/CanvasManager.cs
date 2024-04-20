using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject MoneyCounter;
    public float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
