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
    [SerializeField] Animator animator;
    NavMeshAgent navMesh;
    
    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateUpAxis = false;
        navMesh.updateRotation = false;
    }

    private void Update()
    {
        if (GetDistanceToPlayer() < shootingRange)
        {
            weapon.Shoot(animator);
        }
        else if (GetDistanceToPlayer() < seeingRange)
        {
            print(GetDistanceToPlayer());
            SetDestination(player);
        }
    }
    private void LateUpdate()
    {
        //if (navMesh.velocity.sqrMagnitude > Mathf.Epsilon)
        //{
            float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Mathf.Infinity * Time.deltaTime);

       // }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, seeingRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
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
