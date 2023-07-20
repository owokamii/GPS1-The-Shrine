using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //references
    public CharacterController2D _controller;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    //walk
    private float horizontalMove;
    public float runSpeed;
    bool jump = false;
    bool crouch = false;

    //climb
    private float verticalMove;
    private float climbSpeed = 3f;
    bool _isLadder;
    bool _isClimbing;

    //push
    public LayerMask _crateMask;
    private float _grabDistance = 0.6f;
    bool _isPushing;

    //GameObjects
    AudioManager audioManager;
    GameObject crate;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        //if player is not dead
        if(gameObject.tag != "Dead")
        {
            _animator.SetBool("Dead", false);
            if (!_isPushing)
            {
                runSpeed = 25f;
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            }
            else
            {
                runSpeed = 10f;
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            }

            //up and down movement and the animation
            verticalMove = Input.GetAxis("Vertical");
            _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            _animator.SetFloat("ClimbSpeed", Mathf.Abs(verticalMove));

            if (_isLadder)
            {
                _isClimbing = true;
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, _grabDistance, _crateMask);
            /*RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.x, _grabDistance, _crateMask);
            Debug.Log(ground.collider.gameObject.layer);

            if (ground.collider.gameObject.layer == 9)
            {
                _animator.SetBool("IsClimbing", false);
            }*/

            if(hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Objects" && Input.GetButtonDown("Grab")) //hit.collider != null
                {
                    crate = hit.collider.gameObject;
                    crate.GetComponent<FixedJoint2D>().enabled = true;
                    crate.GetComponent<ObjectPhysics>().beingPushed = true; //not so optimized
                    crate.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                    _isPushing = true;
                    _animator.SetBool("IsPushing", true);
                    audioManager.PlaySFX(audioManager.sfx[1]);
                }
                else if (Input.GetButtonUp("Grab"))
                {
                    crate.GetComponent<FixedJoint2D>().enabled = false;
                    crate.GetComponent<ObjectPhysics>().beingPushed = false; //not so optimized
                    _isPushing = false;
                    _animator.SetBool("IsPushing", false);
                }
            }
        }
        else if(gameObject.tag == "Dead")
        {
            horizontalMove = 0f;
            _animator.SetBool("Dead", true);
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

        if (horizontalMove != 0)
        {
            audioManager.PlaySFX(audioManager.sfx[0]);
        }

        if (_isClimbing && gameObject.tag != "Dead")
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
        }
    }

    //climbing ladder
    private void OnTriggerStay2D(Collider2D collision)
    {
        //probably use raycast to detect if theres a ground, if there is: animation false, if there isn't: animation true
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
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * _grabDistance);
    }
}