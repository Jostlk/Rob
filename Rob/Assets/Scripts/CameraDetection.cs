using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public PlayerController Player;
    public float MinRotation;
    public float MaxRotation;
    public float Speed;
    public float ViewAngle = 30;
    public bool _isPlayerNoticed;
    private DetectionSystem _detectionSystem;
    private void Start()
    {
        _detectionSystem = Player.GetComponent<DetectionSystem>();
    }

    void Update()
    {
        DetectionPlayer();
        if (_isPlayerNoticed)
        {
            _detectionSystem.WhileNoticed();
        }
        if (!_isPlayerNoticed)
        {
            _detectionSystem.WhileNotNoticed();
        }
        if ((int)transform.localEulerAngles.y == MaxRotation)
        {
            Speed = -Speed;
        }
        if ((int)(transform.localEulerAngles.y - 360) == MinRotation)
        {
            Speed = -Speed;
        }
        transform.Rotate(new Vector3(0, Speed * Time.deltaTime, 0), Space.World);
    }

    private void DetectionPlayer()
    {
        RaycastHit hit;
        _isPlayerNoticed = false;
        var direction = Player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {         
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
}
