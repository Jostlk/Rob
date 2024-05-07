﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterKey : MonoBehaviour
{
    public Image masterKey;
    public Material masterKeyMaterial;
    public Image masterKeyUpperLayer;
    public Transform Door;
    public float Range;
    public float Rotate;
    public bool KeyInInventory = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (KeyInInventory == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    masterKeyUpperLayer.fillAmount += Range * Time.deltaTime;
                    if (masterKeyUpperLayer.fillAmount == 1)
                    {
                        Door.Rotate(new Vector3(0, Rotate, 0));
                        Destroy(gameObject);
                    }
                }
                else
                {
                    masterKeyUpperLayer.fillAmount -= 2f * Time.deltaTime;
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
