using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController Player;
    public Image EyeIcon;
    private bool _isPlayerNoticed;
    public float ViewAngle;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
    }

    void Update()
    {
        if (!_isPlayerNoticed)
        {
            EyeIcon.fillAmount -= 0.3f * Time.deltaTime;
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
        NoticePlayerUpdate();
        if (_isPlayerNoticed)
        {
            EyeIcon.fillAmount += 0.3f * Time.deltaTime;
            if (EyeIcon.fillAmount == 1)
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
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }

}
