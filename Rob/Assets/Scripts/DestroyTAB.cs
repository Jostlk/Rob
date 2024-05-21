using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTAB : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Destroy(gameObject);
        }
    }
}
