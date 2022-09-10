using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float seeingRange = 5;
    [SerializeField] float shootingRange = 4;
    [SerializeField] GameObject player;
    [SerializeField] Weapon weapon;
    NavMeshAgent navMesh;
    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateUpAxis = false;
    }

    private void Update()
    {
        if (GetDistanceToPlayer() < shootingRange)
        {
            weapon.Shoot();
            return;
        }
        if (GetDistanceToPlayer() < seeingRange)
        {
            SetDestination(player);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, seeingRange);  
    }
    private float GetDistanceToPlayer()
    {
        return Vector2.Distance(transform.position, player.transform.position);
    }
    void SetDestination(GameObject target)
    {
        var agentDrift = 0.0001f; // minimal
        var driftPos = target.transform.position + (Vector3)(agentDrift * Random.insideUnitCircle);
        navMesh.SetDestination(driftPos);
    }

}
