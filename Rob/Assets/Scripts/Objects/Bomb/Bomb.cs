using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public Image Button;
    public GameObject BombClear;
    public GameObject BombObject;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Capsule")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Button.fillAmount += 0.4f * Time.deltaTime;
                if (Button.fillAmount == 1)
                {
                    Destroy(BombClear);
                    BombObject.SetActive(true);
                    Destroy(gameObject);
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
