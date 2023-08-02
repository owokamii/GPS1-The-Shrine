using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float _maxThirst = 100;
    public float _currentThirst;

    public ParticleSystem sweat;
    public Animator transition;
    public ThirstBar _thirstBar;

    private Transform currentCheckpoint;
    Vector2 _spawnPoint;

    //
    //public GameObject crate1;
    //Vector2 crate1SpawnPoint;
    //Vector2 crate1CurrentPoint;
    //

    void Start()
    {
        _spawnPoint = transform.position;
        _currentThirst = _maxThirst;
        _thirstBar.SetMaxThirst(_maxThirst);
        //crate1SpawnPoint = transform.position;

    }

    void Update()
    {
        if (_currentThirst > _maxThirst)
            _currentThirst = _maxThirst;
        else if (_currentThirst < 0)
            _currentThirst = 0;

        if (gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                Dehydration(2);
            }
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                Dehydration(3);
            }
        }

        if (_currentThirst <= 0)
            Die();

        if (gameObject.CompareTag("Player"))
        {
            if (!sweat.isPlaying)
                sweat.Play();
        }
        else if (gameObject.CompareTag("Immortal"))
        {
            if (sweat.isPlaying)
                sweat.Stop();
        }
       

        //crate1CurrentPoint = transform.position;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles") || collision.gameObject.CompareTag("Enemy"))
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

    void Dehydration(float value)
    {
        _currentThirst -= value * Time.deltaTime;
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
