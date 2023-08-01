using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject bird;
    public float moveSpeed;
    private Animator animator;
    Vector2 spawnPoint;
    public SpriteRenderer sprite;
    public bool slowerSnake = false;

    void Start()
    {
        spawnPoint = transform.position;
        bird.SetActive(false);
    }

    void Update()
    {
        
        animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0f);

        if (moveSpeed > 0 || moveSpeed < 0)
            animator.SetBool("Move", true);
        else if (moveSpeed == 0)
            animator.SetBool("Move", false);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            gameObject.tag = "DeadDead";
            animator.SetBool("Bite", true);
            Invoke("Respawn", 1);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StopDetector"))
        {
            moveSpeed = 0f;
            Invoke("SlitherBack", 2);
            Invoke("Respawn", 4);
        }
    }

    void Respawn()
    {
        bird.transform.position = spawnPoint;
        bird.SetActive(false);
        sprite.flipX = false;
        if (!slowerSnake)
            moveSpeed = 5.3f;
        else
            moveSpeed = 4f;
    }

    void SlitherBack()
    {
        sprite.flipX = true;
        moveSpeed = -9f;
    }

}
