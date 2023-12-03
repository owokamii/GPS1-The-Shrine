/*using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public float _distance = 1f;
    public LayerMask boxMask;
    public bool _isPushing;


    public Animator _animator;

    GameObject box;

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, _distance, boxMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "Objects" && Input.GetButtonDown("Grab"))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<ObjectPhysics>().beingPushed = true; //not so optimized
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            _isPushing = true;
            _animator.SetBool("IsPushing", true);
        }
        else if(Input.GetButtonUp("Grab"))
        {
           box.GetComponent<FixedJoint2D>().enabled = false;
           box.GetComponent<ObjectPhysics>().beingPushed = false; //not so optimized
            _isPushing = false;
            _animator.SetBool("IsPushing", false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * _distance);
    }
}*/