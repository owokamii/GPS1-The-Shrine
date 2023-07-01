using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private float verticalMove;
    private float speed = 3f;
    private bool _isLadder;
    public bool _isClimbing;
    public Animator _animator;

    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        _animator.SetFloat("ClimbSpeed", Mathf.Abs(verticalMove));

        if (_isLadder)
        {
            _isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if(_isClimbing)
        {
            _rb.gravityScale = 0f;
            _rb.velocity = new Vector2(_rb.velocity.x, verticalMove * speed);
            _animator.SetBool("IsClimbing", true);
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
            _isLadder = true;
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
            _isLadder = false;
            _isClimbing = false;
            _animator.SetBool("IsClimbing", false);
        }
    }
}