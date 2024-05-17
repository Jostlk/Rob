using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public List<GameObject> Keys;
    public void SpawnKeys()
    {
        Keys[Random.Range(0, Keys.Count)].SetActive(true);
        Destroy(gameObject);
    }
}
