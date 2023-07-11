using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Vector3 originalPos;
    bool moveBack = false;

    void Start()
    {
        originalPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Asher 2")
        {
            collision.transform.parent = transform;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.name == "Asher 2")
        {
            transform.Translate(0, -0.01f, 0);
            moveBack = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.name == "Asher 2")
        {
            moveBack = true;
            collision.transform.parent = null;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void Update()
    {
        if(moveBack)
        {
            if(transform.position.y < originalPos.y)
            {
                transform.Translate(0, 0.01f, 0);
            }
            else
            {
                moveBack = false;
            }
        }
    }
}
