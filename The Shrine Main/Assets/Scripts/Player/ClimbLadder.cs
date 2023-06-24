using Unity.VisualScripting;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    public float _speed;
    private Rigidbody2D _rb;
    private float _inputHorizontal;
    private float _inputVertical;
    public float _distance;
    public LayerMask _whatIsLadder;
    private bool isClimbing;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_inputHorizontal * _speed, _rb.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, _distance, _whatIsLadder);

        if(hitInfo.collider != null)
        {
            Debug.Log("test1");
            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("test2");
                isClimbing = true;
            }
        }

        if(isClimbing == true)
        {
            _inputVertical = Input.GetAxisRaw("Vertical");
            _rb.velocity = new Vector2(_rb.position.x, _inputVertical * _speed);
            _rb.gravityScale = 0;
            Debug.Log("test3");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * _distance);
    }
}