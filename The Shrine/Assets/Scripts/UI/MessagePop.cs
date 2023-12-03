using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePop : MonoBehaviour
{
    public GameObject message;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Message Popping"); // Dunno why its not even triggering , why ?
            message.SetActive(true);
        }
        if (collision.gameObject.tag == "Immortal")
        {
            Debug.Log("Message Popping"); // Dunno why its not even triggering , why ?
            message.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Message  not Popping");
            message.SetActive(false);
        }
        if (collision.gameObject.tag == "Immortal")
        {
            Debug.Log("Message  not Popping"); // Dunno why its not even triggering , why ?
            message.SetActive(false);
        }
    }


   

}
