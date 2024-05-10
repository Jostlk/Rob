using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public List<GameObject> Keys;
    public TextMeshProUGUI ObjectiveText;
    private void Update()
    {
        if(ObjectiveText.text == "Найти ключ")
        {
            Keys[Random.Range(0,Keys.Count)].SetActive(true);
            Destroy(gameObject);
        }
    }
}
