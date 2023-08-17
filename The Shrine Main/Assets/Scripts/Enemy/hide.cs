using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject bird;
    public float moveSpeed;
    private Animator animator;
    Vector2 spawnPoint;
    public SpriteRenderer sprite;
    public bool slowerSnake = false;

    const float timeBetweenHisses = 3f;
    float lastPlayedHissesSoundTime = -timeBetweenHisses;

    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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

        if (moveSpeed != 0)
        {
            if (Time.timeSinceLevelLoad - lastPlayedHissesSoundTime > timeBetweenHisses)
            {
                audioManager.PlaySFX(audioManager.sfx[10]);
                lastPlayedHissesSoundTime = Time.timeSinceLevelLoad;
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Debug.Log("detected player");
            animator.SetBool("Bite", true);
            Invoke("StopBiting", 0.5f);
            Invoke("Respawn", 3);
            
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

    void StopBiting()
    {
        animator.SetBool("Bite", false);
        moveSpeed = 0f;
    }

    void SlitherBack()
    {
        sprite.flipX = true;
        moveSpeed = -9f;
    }

}
