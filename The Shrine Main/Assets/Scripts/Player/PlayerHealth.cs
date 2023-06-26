using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _maxThirst = 100;
    public float _currentThirst;

    public ThirstBar _thirstBar;

    private Transform currentCheckpoint;
    Vector2 _spawnPoint;

    void Start()
    {
        _spawnPoint = transform.position;
        _currentThirst = _maxThirst;
        _thirstBar.SetMaxThirst(_maxThirst);
    }

    void Update()
    {
        if(gameObject.tag == "Player")
        {
            Dehydration();
        }

        if (_currentThirst <= 0)
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
            _spawnPoint = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Dehydration()
    {
        _currentThirst -= 2 * Time.deltaTime;
        _thirstBar.SetThirst(_currentThirst);
    }

    
    public void Hydration()
    {  
        _currentThirst += 20;
        _thirstBar.SetThirst(_currentThirst);
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = _spawnPoint;
        _currentThirst = _maxThirst;
        _thirstBar.SetMaxThirst(_maxThirst);
    }
}
