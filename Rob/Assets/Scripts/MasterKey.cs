using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterKey : MonoBehaviour
{
    public Image masterKey;
    public Transform Door;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if(Input.GetKey(KeyCode.E))
            {
                masterKey.fillAmount += 0.1f * Time.deltaTime;
                if (masterKey.fillAmount == 1)
                {
                    Door.Rotate(new Vector3(0,90,0));
                    Destroy(gameObject);
                }
            }
            else
            {
                masterKey.fillAmount = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Capsule")
        {
            masterKey.fillAmount = 0;
        }
    }
}
