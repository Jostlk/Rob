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
    //public Transform Door;
    public Door door;
    public ObjectiveManager objectiveManager;
    public AudioSource MetalDoorOpen;
    public AudioSource OpenLock;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Button.fillAmount += Timer * Time.deltaTime;
                if (!OpenLock.isPlaying)
                {
                    OpenLock.Play();
                }
                if (Button.fillAmount == 1)
                {
                    OpenLock.Stop();
                    if (keyCount > 0)
                    {
                        MetalDoorOpen.Play();
                        keyCount--;
                        door.Interact();
                        //Door.Rotate(new Vector3(0, Rotate, 0));
                        objectiveManager.SwitchObjectiveTo(4);
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
                OpenLock.Stop();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Button.fillAmount = 0;
    }
}
