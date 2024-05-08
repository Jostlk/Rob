using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public float Timer;
    public Image Button;
    public GameObject KeyGameobject;
    public MeshRenderer KeyMeshRenderer;
    public OpenKeyDoor openKeyDoor;
    public AudioSource KeySound;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Button.fillAmount += Timer * Time.deltaTime;
                if (Button.fillAmount == 1)
                {
                    KeySound.Play();
                    openKeyDoor.keyCount++;
                    if (KeyGameobject.name != "key_gold")
                    {
                        MoneyCounter.WinBalance += 144000;
                    }
                    Destroy(gameObject);
                    KeyMeshRenderer.enabled = false;
                    Destroy(KeyGameobject,1);

                }
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                Button.fillAmount = 0;
            }
        }
    }
}
