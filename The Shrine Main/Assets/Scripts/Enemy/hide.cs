using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject bird;
    public float moveSpeed;
    private Animator animator;
    Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;
        bird.SetActive(false);
    }

    void Update()
    {
        
        animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            Debug.Log("Player kill");
            bird.SetActive(false);
            Respawn();
            //Instantiate(bird, spawnPoint.position, Quaternion.identity);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StopDetector"))
        {
            moveSpeed = 0f;
            animator.SetTrigger("StopDetector");
        }
    }

    void Respawn()
    {
        bird.transform.position = spawnPoint;
        moveSpeed = 4.5f;
    }

}
