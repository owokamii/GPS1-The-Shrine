using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private float vertical;
    private float speed = 3f;
    private bool isLadder;
    public bool _isClimbing;
    public Animator _animator;

    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder)
        {
            _isClimbing = true;
            _animator.SetBool("IsClimbing", true);
        }
    }

    private void FixedUpdate()
    {
        if(_isClimbing)
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
            _isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            _isClimbing = false;
            _animator.SetBool("IsClimbing", false);
        }
    }
}