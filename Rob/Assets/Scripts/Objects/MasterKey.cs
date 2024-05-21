using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasterKey : MonoBehaviour
{
    static public bool TipsOn = false;
    static public bool DestroyPressE = false;
    public Image masterKey;
    public Material masterKeyMaterial;
    public Image masterKeyUpperLayer;
    public GameObject PressE;
    public Door door;
    public AudioSource LockSound;
    public AudioSource OpenDoorSound;
    public float Range;
    public float Rotate;
    public bool KeyInInventory = false;
    private void OnTriggerEnter(Collider other)
    {
        if (TipsOn == false && DestroyPressE == false)
        {
            PressE.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (KeyInInventory == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    masterKeyUpperLayer.fillAmount += Range * Time.deltaTime;
                    if (!LockSound.isPlaying)
                    {
                        LockSound.Play();
                    }
                    if (masterKeyUpperLayer.fillAmount == 1)
                    {
                        DestroyPressE = true;
                        Destroy(PressE);
                        OpenDoorSound.Play();
                        Destroy(gameObject);
                        door.Interact();
                    }
                }
                else
                {
                    masterKeyUpperLayer.fillAmount -= 2f * Time.deltaTime;
                    LockSound.Stop();
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
            if (DestroyPressE == false)
            {
                PressE.SetActive(false);
            }
            LockSound.Stop();
            masterKey.color = Color.white;
            masterKey.material = masterKeyMaterial;
            masterKeyUpperLayer.fillAmount = 0;
        }
    }
}
