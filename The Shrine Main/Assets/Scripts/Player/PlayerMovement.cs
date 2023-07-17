using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //references
    public CharacterController2D _controller;
    [SerializeField] private Rigidbody2D _rb;
    public Animator _animator;

    //walk
    private float horizontalMove;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    //climb
    private float verticalMove;
    public float climbSpeed = 3f;
    bool _isLadder;
    bool _isClimbing;

    //push
    public LayerMask boxMask;
    public float _distance = 1f;
    bool _isPushing;

    AudioManager audioManager;
    GameObject box;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        //if player is not dead
        if(gameObject.tag != "Dead")
        {
            //left and right movement and the animation
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            //up and down movement and the animation
            verticalMove = Input.GetAxis("Vertical");
            _animator.SetFloat("ClimbSpeed", Mathf.Abs(verticalMove));

            if (_isLadder)
            {
                _isClimbing = true;
            }

            if (horizontalMove == 0)
            {
                //FindObjectOfType<AudioManager>().Play("PlayerWalk");
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                //animator.SetBool("isJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }

            Physics2D.queriesStartInColliders = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, _distance, boxMask);
            RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.x, _distance, boxMask);
            Debug.Log(ground.collider.gameObject.layer);

            if(ground.collider.gameObject.layer == 9)
            {
                _isClimbing = false;
            }

            if (hit.collider != null && hit.collider.gameObject.tag == "Objects" && Input.GetButtonDown("Grab"))
            {
                box = hit.collider.gameObject;
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<ObjectPhysics>().beingPushed = true; //not so optimized
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                _isPushing = true;
                _animator.SetBool("IsPushing", true);
                audioManager.PlaySFX(audioManager.sfx[0]);
            }
            else if (Input.GetButtonUp("Grab"))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                box.GetComponent<ObjectPhysics>().beingPushed = false; //not so optimized
                _isPushing = false;
                _animator.SetBool("IsPushing", false);
            }
        }
    }

    public void OnLanding()
    {
        //animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        _animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        _controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, _isPushing);
        jump = false;

        if (_isClimbing)
        {
            _rb.gravityScale = 0f;
            _rb.velocity = new Vector2(_rb.velocity.x, verticalMove * climbSpeed);
            if (Input.GetButton("Vertical"))
            {
                _animator.SetBool("IsClimbing", true);
            }
        }
        else
        {
            _rb.gravityScale = 3f;
        }
    }

    //enter ladder
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isLadder = true;
            if(Input.GetButtonDown("Vertical"))
            {
                _isClimbing = true;
            }
        }
    }

    //climbing ladder
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            //probably use raycast to detect if theres a ground, if there is: animation false, if there isn't: animation true
            _isClimbing = true;
            _animator.SetBool("IsClimbing", true);
        }
    }

    //exit ladder
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isLadder = false;
            _isClimbing = false;
            _animator.SetBool("IsClimbing", false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * _distance);
    }
}