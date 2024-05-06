using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public float Timer;
    public Image Button;
    public GameObject KeyGameobject;
    public OpenKeyDoor openKeyDoor;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Button.fillAmount += Timer * Time.deltaTime;
                if (Button.fillAmount == 1)
                {
                    openKeyDoor.keyCount++;
                    Destroy(KeyGameobject);
                }
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                Button.fillAmount = 0;
            }
        }
    }
}
