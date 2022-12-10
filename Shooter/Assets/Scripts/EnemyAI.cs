using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float seeingRange = 5;
    [SerializeField] float shootingRange = 4;
    [SerializeField] GameObject player;
    [SerializeField] Weapon weapon;
    [SerializeField] Animator animator;
    [SerializeField] Transform playerTranform;
    [SerializeField] LayerMask layerMask;
    NavMeshAgent navMesh;
    bool haveSeenPlayer = false;   
    RaycastHit2D[] walls;


    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateUpAxis = false;
        navMesh.updateRotation = false;
    }

    private void Update()
    {
        walls = Physics2D.RaycastAll(transform.position, GetDirectionToPlayer(), GetDistanceToPlayer(), layerMask);
        Debug.DrawRay(transform.position, GetDirectionToPlayer() * GetDistanceToPlayer() , Color.red);      

        if (!haveSeenPlayer)
        {
            haveSeenPlayer = !walls.Any() && GetDistanceToPlayer() < seeingRange;
            return;
        }

        if (GetDistanceToPlayer() < shootingRange)
        {
            if (!walls.Any())
            {
                weapon.Attack(animator);
            }
        }

        SetDestination(player);
    }

    private void LateUpdate()
    {
        //if (navMesh.velocity.sqrMagnitude > Mathf.Epsilon)
        //{
        if (haveSeenPlayer)
        {
            float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Mathf.Infinity * Time.deltaTime);
        }
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

    private Vector2 GetDirectionToPlayer()
    {
        Vector2 direction = playerTranform.position - transform.position;
        direction.Normalize();
        return direction;
    }

    void SetDestination(GameObject target)
    {
        var agentDrift = 0.0001f; // minimal
        var driftPos = target.transform.position + (Vector3)(agentDrift * Random.insideUnitCircle);
        navMesh.SetDestination(driftPos);
    }

}
