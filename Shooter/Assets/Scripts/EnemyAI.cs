using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float seeingRange = 5;
    [SerializeField] Transform player;
    void Start()
    {
        
    }

    void Update()
    {
        if(GetDistanceToPlayer() < seeingRange)
        {
            print("i see player");
        }
    }
    private float GetDistanceToPlayer()
    {
        return Vector2.Distance(transform.position, player.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, seeingRange);
    }
}
