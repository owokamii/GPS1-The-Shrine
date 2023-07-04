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
            // Calculate the movement direction
            Vector2 movementDirection = isMovingRight ? Vector2.right : Vector2.left;

            // Calculate the next position based on the movement direction and speed
            Vector2 nextPosition = (Vector2)transform.position + (movementDirection * patrolSpeed * Time.deltaTime);

            // Perform a raycast to check for obstacles in the movement direction
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, raycastDistance, obstacleLayer);

            // If an obstacle is detected or the enemy reaches the patrol distance, flip its direction
            if (hit.collider != null || Mathf.Abs(nextPosition.x - initialPosition.x) >= patrolDistance)
            {
                Flip();
            }
            else
            {
                // Move the enemy to the next position
                transform.position = nextPosition;
            }
        }
    }

    private void Flip()
    {
        isMovingRight = !isMovingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // Adjust the position slightly to avoid getting stuck in corners
        Vector3 newPosition = transform.position;
        newPosition.x += isMovingRight ? 0.1f : -0.1f;
        transform.position = newPosition;
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
