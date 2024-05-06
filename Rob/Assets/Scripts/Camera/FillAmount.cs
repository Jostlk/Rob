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
            _detectionSystem.WhileNoticed();
        }
        if (_playerNoticedCount == 0)
        {
            _detectionSystem.WhileNotNoticed();
        }
    }
}
