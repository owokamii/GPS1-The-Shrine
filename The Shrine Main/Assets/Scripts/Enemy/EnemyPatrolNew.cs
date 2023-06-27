using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolNew : MonoBehaviour
{
    public float patrolDistance = 2f;
    public float patrolSpeed = 2f;
    public float raycastDistance = 1f;
    public LayerMask obstacleLayer;

    private bool isMovingRight = true;
    private bool isColliding = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!isColliding)
        {
            if (isMovingRight)
            {
                transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
                if (transform.position.x >= initialPosition.x + patrolDistance || CheckObstacleAhead())
                {
                    Flip();
                }
            }
            else
            {
                transform.Translate(Vector2.left * patrolSpeed * Time.deltaTime);
                if (transform.position.x <= initialPosition.x - patrolDistance || CheckObstacleAhead())
                {
                    Flip();
                }
            }
        }
    }

    private void Flip()
    {
        isMovingRight = !isMovingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private bool CheckObstacleAhead()
    {
        Vector2 raycastDirection = isMovingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, raycastDistance, obstacleLayer);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsObstacleCollision(collision))
        {
            isColliding = true;
            Flip();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsObstacleCollision(collision))
        {
            isColliding = false;
        }
    }

    private bool IsObstacleCollision(Collision2D collision)
    {
        return (obstacleLayer & (1 << collision.gameObject.layer)) != 0;
    }
}
