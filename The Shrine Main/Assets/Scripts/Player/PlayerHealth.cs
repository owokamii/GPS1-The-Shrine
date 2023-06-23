using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxThirst = 100;
    public float currentThirst;

    public ThirstBar thirstBar;

    private Transform currentCheckpoint;
    Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;
        currentThirst = maxThirst;
        thirstBar.SetMaxThirst(maxThirst);
    }

    void Update()
    {
        if(gameObject.tag == "Player")
        {
            Dehydration();
        }

        if (currentThirst < 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacles")
        {
            Die();
        }
        if (collision.transform.tag == "Checkpoint")
        {
            spawnPoint = transform.position;
        }
    }

    void Dehydration()
    {
        currentThirst -= 1 * Time.deltaTime;
        thirstBar.SetThirst(currentThirst);
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = spawnPoint;
    }
}
