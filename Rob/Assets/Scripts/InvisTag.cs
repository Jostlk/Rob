//Этот скрипт просто отключает MeshRenderer у всех объектов с тегом Invisible
using UnityEngine;

public class InvisTag : MonoBehaviour
{
    private GameObject[] invisObjects;
    void Start()
    {
        invisObjects = GameObject.FindGameObjectsWithTag("Invisible");
        foreach (GameObject item in invisObjects)
        {
            var meshRenderer = item.GetComponent<MeshRenderer>();
            meshRenderer.enabled = !meshRenderer.enabled;
        }
    }
}
