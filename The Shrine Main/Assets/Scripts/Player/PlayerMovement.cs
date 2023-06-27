using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D _controller;
    public ClimbLadder _climbLadder;
    public GrabObject _grabObject;
    public Animator _animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

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
        _controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, _grabObject._isPushing, _climbLadder._isClimbing);
        jump = false;
    }
}