using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public PlayerController Player;
    public List<Transform> PatrolPoints;
    public Animator animator;
    public float TimeNewPoint = 3;
    private float ViewAngle;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private DetectionSystem _detectionSystem;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _detectionSystem = Player.GetComponent<DetectionSystem>();
        PickNewPatrolPoint();
    }

    void Update()
    {
        ViewAngle = Player.EnemysViewAngle;
        NoticePlayerUpdate();
        if (!_isPlayerNoticed)
        {
            _detectionSystem.WhileNotNoticed();

            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetBool("NewPoint", true);
                if (!IsInvoking())
                {
                    Invoke("PickNewPatrolPoint", TimeNewPoint);
                }
            }
        }

        if (_isPlayerNoticed)
        {
            _detectionSystem.WhileNoticed();
            if (_detectionSystem.detectionLevel == 1)
            {
                _navMeshAgent.destination = Player.transform.position;
            }
        }

    }

    private void NoticePlayerUpdate()
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

    private void PickNewPatrolPoint()
    {
        animator.SetBool("NewPoint", false);
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }

}
