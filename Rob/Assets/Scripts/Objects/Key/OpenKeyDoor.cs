using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class OpenKeyDoor : MonoBehaviour
{
    public int keyCount = 0;
    public float Rotate;
    public float Timer;
    public Image Button;
    public Transform Door;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Button.fillAmount += Timer * Time.deltaTime;
                if (Button.fillAmount == 1)
                {
                    if (keyCount > 0)
                    {
                        keyCount--;
                        Door.Rotate(new Vector3(0, Rotate, 0));
                        Destroy(gameObject);
                    }
                    else
                    {
                        Button.fillAmount = 0;
                    }
                }
            }
            else
            {
                Button.fillAmount -= 2 * Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Button.fillAmount = 0;
    }
}
