using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unhide : MonoBehaviour
{
    public GameObject bird;
    public Transform spawnPoint;
    // Start is called before the first frame update
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // Code to handle the collision with the detector
    //        Debug.Log("Player collided with detector");
    //        bird.SetActive(true);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Immortal"))
        {
            // Code to handle the collision with the detector
            Debug.Log("Player collided with detector");

            bird.SetActive(true);
        }
    }

}
