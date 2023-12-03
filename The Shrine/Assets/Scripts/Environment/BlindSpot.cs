using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.tag = "Immortal";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.tag = "Immortal";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Immortal"))
            collision.gameObject.tag = "Player";
    }
}
