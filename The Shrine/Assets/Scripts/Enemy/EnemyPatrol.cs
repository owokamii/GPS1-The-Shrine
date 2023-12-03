using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public Transform currentPoint;
    private Rigidbody2D rb;
    public float speed;
    public float idleTime = 1f; // Duration of idle time in seconds
    private bool isIdle = false;
    private float idleTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isIdle)
        {
            Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {
                flip();
                currentPoint = pointA.transform;
                StartIdleTimer();
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                flip();
                currentPoint = pointB.transform;
                StartIdleTimer();
            }
        }
        else
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                StopIdleTimer();
                ResumeMovement();
            }
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isIdle && collision.gameObject.CompareTag("Objects"))
        {
            flip();
            StopMovement();
            StartIdleTimer();
            // Switch the current point to the opposite one
            if (currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }
            else
            {
                currentPoint = pointA.transform;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void StartIdleTimer()
    {
        isIdle = true;
        StopMovement();
        idleTimer = 0f;
    }

    private void StopIdleTimer()
    {
        isIdle = false;
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private void ResumeMovement()
    {
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}
