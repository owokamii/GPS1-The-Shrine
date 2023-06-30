using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _ceilingCheck;
    [SerializeField] private Collider2D _crouchDisableCollider;
    [SerializeField] private Animator _animator;

    //walk
    [Range(0, .3f)][SerializeField] private float _movementSmoothing = .05f;

    //jump
    [SerializeField] private float _jumpForce = 400f;
    [SerializeField] private bool _airControl = false;

    //crouch
    [Range(0, 1)][SerializeField] private float _crouchSpeed = .36f;
    //[SerializeField] private GrabObject _grabObject;

    const float _groundedRadius = .2f;
    private bool _grounded;
    const float _ceilingRadius = .2f;
    private Rigidbody2D _rb;
    private bool _facingRight = true;
    private Vector3 _velocity = Vector3.zero;

    public UnityEvent OnLandEvent;
    public ParticleSystem dust;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool _wasCrouching = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = _grounded;
        _grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool crouch, bool jump, bool isPushing, bool isClimbing)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(_ceilingCheck.position, _ceilingRadius, _whatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (_grounded || _airControl)
        {
            // If crouching
            if (crouch)
            {
                if (!_wasCrouching)
                {
                    _wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }
                move *= _crouchSpeed;

                // Disable one of the colliders when crouching
                if (_crouchDisableCollider != null)
                    _crouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (_crouchDisableCollider != null)
                    _crouchDisableCollider.enabled = true;

                if (_wasCrouching)
                {
                    _wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
            // And then smoothing it out and applying it to the character
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _movementSmoothing);

            if (!isPushing)
            {
                if (move > 0 && !_facingRight)
                {
                    Flip();
                }
                else if (move < 0 && _facingRight)
                {
                    Flip();
                }
            }
        }
        // If the player should jump...
        if (_grounded && jump && !_wasCrouching)
        {
            // Add a vertical force to the player.
            _grounded = false;
            _rb.AddForce(new Vector2(0f, _jumpForce));
            CreateDust();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        CreateDust();
    }

    void CreateDust()
    {
        dust.Play();
    }

}