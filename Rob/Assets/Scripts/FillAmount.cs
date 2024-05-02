using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillAmount : MonoBehaviour
{
    public int _playerNoticedCount = 0;
    public DetectionSystem _detectionSystem;
    void Update()
    {
        if (_playerNoticedCount > 0)
        {
            Debug.Log("FillAmount");
            _detectionSystem.WhileNoticed();
        }
        if (_playerNoticedCount == 0)
        {
            Debug.Log("FillAmount222");
            _detectionSystem.WhileNotNoticed();
        }
    }
}
