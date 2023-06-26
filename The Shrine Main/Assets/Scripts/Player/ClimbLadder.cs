using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    private float vertical;
    private float speed = 2f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D _rb;

    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            _rb.gravityScale = 0f;
            _rb.velocity = new Vector2(_rb.velocity.x, vertical * speed);
        }
        else
        {
            _rb.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}