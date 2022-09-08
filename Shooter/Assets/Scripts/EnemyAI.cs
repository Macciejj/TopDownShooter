using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float seeingRange = 5;
    [SerializeField] Transform player;
    [SerializeField] float angle = 30;
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
    
    private void OnDrawGizmos()
    {
        float angleInRadians = angle * Mathf.PI / 180;

        Gizmos.DrawWireSphere(transform.position, seeingRange);

        Gizmos.color = Color.green;
        float xEndOfRadiusPosition = -seeingRange * Mathf.Cos(angleInRadians) + transform.position.x;
        float yEndOfRadiusPosition = -seeingRange * Mathf.Sin(angleInRadians) + transform.position.y;
        Gizmos.DrawLine(transform.position, new Vector3(xEndOfRadiusPosition, yEndOfRadiusPosition, 0));

        float xEndOfRadiusPosition2 = seeingRange * Mathf.Cos(-angleInRadians) + transform.position.x;
        float yEndOfRadiusPosition2 = seeingRange * Mathf.Sin(-angleInRadians) + transform.position.y;
        Gizmos.DrawLine(transform.position, new Vector3(xEndOfRadiusPosition2, yEndOfRadiusPosition2, 0));
    }
    private float GetDistanceToPlayer()
    {
        return Vector2.Distance(transform.position, player.position);
    }

    private void Chase()
    {

    }

}
