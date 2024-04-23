using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterKey : MonoBehaviour
{
    public Image masterKey;
    public Material masterKeyMaterial;
    public Image masterKeyUpperLayer;
    public Transform Door;
    public bool KeyInInventory = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (KeyInInventory == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    masterKeyUpperLayer.fillAmount += 0.1f * Time.deltaTime;
                    if (masterKeyUpperLayer.fillAmount == 1)
                    {
                        Door.Rotate(new Vector3(0, 90, 0));
                        Destroy(gameObject);
                    }
                }
                else
                {
                    masterKeyUpperLayer.fillAmount = 0;
                }
            }
            else
            {
                masterKey.color = Color.red;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Capsule")
        {
            masterKey.color = Color.white;
            masterKey.material = masterKeyMaterial;
            masterKeyUpperLayer.fillAmount = 0;
        }
    }
}
