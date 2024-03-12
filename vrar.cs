using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [Header("скорость обычная")][Range(1, 30)] public float moveSpeed = 5f;
    [Header("дальносить определимости")][Range(1, 10000)] public float followDistance = 10f;
    [Header("дистанция на которой стоит остановиться от игрока")][Range(1, 20)] public float stoppingDistance = 2f;
    [Header("скорость преследования")][Range(1, 200)] public float followSpeed = 7f;
    
    public Transform player;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        Vector2 direction = player.position - transform.position;
        float distanceToPlayer = direction.magnitude;

        if (distanceToPlayer <= followDistance)
        {

            if (distanceToPlayer > stoppingDistance)
            {
              
                Vector2 moveDirection = direction.normalized;
                rb.velocity = moveDirection * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.velocity = Random.insideUnitCircle.normalized * moveSpeed;
        }
    }
}
