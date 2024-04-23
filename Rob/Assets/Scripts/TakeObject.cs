using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeObject : MonoBehaviour
{
    public Image Button;
    public GameObject Object;
    public MasterKey masterKey;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Button.fillAmount += 0.8f * Time.deltaTime;
            if (Button.fillAmount == 1)
            {
                masterKey.KeyInInventory = true;
                Destroy(Object);
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Button.fillAmount = 0;
        }
    }
}
