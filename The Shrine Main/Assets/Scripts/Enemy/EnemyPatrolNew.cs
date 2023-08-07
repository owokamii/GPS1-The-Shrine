using System.Collections;
using UnityEngine;

public class EnemyPatrolNew : MonoBehaviour
{
    public float patrolDistance = 5f;
    public float patrolSpeed = 2f;
    public float raycastDistance = 10f;
    public LayerMask obstacleLayer;

    private bool isFacingRight = true;
    private bool isColliding = false;
    private bool noticed = false;
    private Vector3 initialPosition;
    public Animator animator;
    AudioManager audioManager;
    public GameObject exMark;
    public AudioSource exMarkSFX;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        initialPosition = transform.position;
        animator.SetBool("Walking", true);
    }

    private void Update()
    {
        if (!isColliding)
        {
            Vector2 movementDirection = isFacingRight ? Vector2.right : Vector2.left;
            Vector2 nextPosition = (Vector2)transform.position + (movementDirection * patrolSpeed * Time.deltaTime);

            //RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, raycastDistance, obstacleLayer);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, raycastDistance, obstacleLayer);

            if (Mathf.Abs(nextPosition.x - initialPosition.x) >= patrolDistance)
            {
                Idle();
            }
            else
            {
                transform.position = nextPosition;
            }

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player") && !noticed)
                {
                    Noticed();
                    Invoke("Chase", 0.5f);
                }
                if(hit.collider.CompareTag("Objects"))
                {

                }
            }
        }
    }

    private void Idle()
    {
        exMark.SetActive(false);
        patrolSpeed = 0;
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        Invoke("Flip", 2);
    }

    private void Noticed()
    {
        exMark.SetActive(true);
        exMarkSFX.Play();
        noticed = true;
        patrolSpeed = 0;
        audioManager.PlaySFX(audioManager.sfx[2]);
        animator.SetBool("Walking", false);
    }

    private void Chase()
    {
       
        patrolSpeed = 4f;
        animator.SetBool("Running", true);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        animator.SetBool("Walking", true);
        patrolSpeed = 2f;
        noticed = false;

        Vector3 newPosition = transform.position;
        newPosition.x += isFacingRight ? 0.1f : -0.1f;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(noticed)
        {
            if(collision.gameObject.CompareTag("Objects"))
            {
                Destroy(collision.gameObject);
            }
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsObstacleCollision(collision))
        {
            Idle();
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * raycastDistance);
    }
}
