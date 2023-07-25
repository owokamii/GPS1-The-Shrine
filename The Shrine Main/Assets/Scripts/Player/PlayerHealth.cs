using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _maxThirst = 100;
    public float _currentThirst;
    public Animator transition;

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
        if(_currentThirst > _maxThirst)
            _currentThirst = _maxThirst;
        else if(_currentThirst < 0)
            _currentThirst = 0;

        if(gameObject.tag == "Player")
            Dehydration();

        if (_currentThirst <= 0)
            Die();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
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
        if(gameObject.tag == "Player" || gameObject.tag == "Immortal")
            if (collision.gameObject.CompareTag("Obstacles") || collision.gameObject.CompareTag("Enemy"))
                Die();
    }

    void Dehydration()
    {
        _currentThirst -= 1.5f * Time.deltaTime;
        _thirstBar.SetThirst(_currentThirst);
    }

    
    public void Hydration()
    {  
        _currentThirst += 20;
        _thirstBar.SetThirst(_currentThirst);
    }

    void Die()
    {
        gameObject.tag = "Dead";
        transition.SetTrigger("Start");
        Invoke("Respawn", 3);
    }

    void Respawn()
    {
        transition.SetTrigger("End");
        gameObject.tag = "Player";
        transform.position = _spawnPoint;
        _currentThirst = _maxThirst;
        _thirstBar.SetMaxThirst(_maxThirst);
    }
}
