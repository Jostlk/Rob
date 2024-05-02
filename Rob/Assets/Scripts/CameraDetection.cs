using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public PlayerController Player;
    public DetectionSystem _detectionSystem;
    public FillAmount _fillAmount;
    public float MinRotation;
    public float MaxRotation;
    public float Speed;
    public float ViewAngle = 30;
    public bool _isPlayerNoticed;
    public bool Flag = false;

    private void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        _fillAmount = FindObjectOfType<FillAmount>();
        _detectionSystem = Player.GetComponent<DetectionSystem>();
    }
    void Update()
    {
        DetectionPlayer();
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
        var direction = Player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    Debug.DrawRay(transform.position,direction, Color.green);
                    if (Flag == false)
                    {
                        Debug.Log("Ray");
                        _fillAmount._playerNoticedCount++;
                        Flag = true;
                    }
                }
                else
                {
                    if (Flag == true)
                    {
                        _fillAmount._playerNoticedCount--;
                        Flag = false;
                    }
                }
            }
            else
            {
                if (Flag == true)
                {
                    _fillAmount._playerNoticedCount--;
                    Flag = false;
                }
            }
        }
        else
        {
            if (Flag == true)
            {
                _fillAmount._playerNoticedCount--;
                Flag = false;
            }
        }
    }
}
