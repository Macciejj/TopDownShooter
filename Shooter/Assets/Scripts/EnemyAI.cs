using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float seeingRange = 5;
    [SerializeField] GameObject player;
    [SerializeField] float angle = 30;
    NavMeshAgent navMesh;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateUpAxis = false;
    }

    void Update()
    {
        if(GetDistanceToPlayer() < seeingRange)
        {
            SetDestination(player);
        }
    }
    void SetDestination(GameObject target)
    {
        var agentDrift = 0.0001f; // minimal
        var driftPos = target.transform.position + (Vector3)(agentDrift * Random.insideUnitCircle);
        navMesh.SetDestination(driftPos);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, seeingRange);
        //float angleInRadians = angle * Mathf.PI / 180 + transform.rotation.z;

        

        //Gizmos.color = Color.green;
        //float xEndOfRadiusPosition = -seeingRange * Mathf.Cos(angleInRadians) + transform.position.x;
        //float yEndOfRadiusPosition = -seeingRange * Mathf.Sin(angleInRadians) + transform.position.y;
        //Gizmos.DrawLine(transform.position, new Vector3(xEndOfRadiusPosition, yEndOfRadiusPosition, 0));

        //float xEndOfRadiusPosition2 = seeingRange * Mathf.Cos(-angleInRadians) + transform.position.x;
        //float yEndOfRadiusPosition2 = seeingRange * Mathf.Sin(-angleInRadians) + transform.position.y;
        //Gizmos.DrawLine(transform.position, new Vector3(xEndOfRadiusPosition2, yEndOfRadiusPosition2, 0));

        
    }
    private float GetDistanceToPlayer()
    {
        return Vector2.Distance(transform.position, player.transform.position);
    }

    private void Chase()
    {

    }

}
