using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float _maxThirst = 100;
    public float _currentThirst;

    public ParticleSystem sweat;
    public Animator transition;
    public ThirstBar _thirstBar;

    Vector2 _spawnPoint;

    public Checkpoint checkpoint;
    [SerializeField] private InteractObject waterVase1;
    [SerializeField] private InteractObject waterVase2;
    [SerializeField] private InteractObject waterVase3;
    [SerializeField] private InteractObject waterVase4;
    [SerializeField] private InteractObject waterVase5;
    [SerializeField] private InteractObject waterVase6;
    [SerializeField] private InteractObject waterVase7;
    //________________________________________________
    //
    [SerializeField] private InteractObject waterPond1;
    [SerializeField] private InteractObject waterPond2;
    [SerializeField] private InteractObject waterPond3;
    [SerializeField] private InteractObject waterPond4;
    [SerializeField] private InteractObject waterPond5;
    [SerializeField] private InteractObject waterPond6;
    [SerializeField] private InteractObject waterPond7;
    [SerializeField] private InteractObject waterPond8;
    [SerializeField] private InteractObject waterPond9;
    [SerializeField] private InteractObject waterPond10;
    [SerializeField] private InteractObject waterPond11;

    void Start()
    {
        _spawnPoint = transform.position;
        _currentThirst = _maxThirst;
        _thirstBar.SetMaxThirst(_maxThirst);
    }

    void Update()
    {
        if (_currentThirst > _maxThirst)
        {
            _currentThirst = _maxThirst;
        }
        else if (_currentThirst < 0)
        {
            _currentThirst = 0;
        }

        if (gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                Dehydration(2);
            }
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                Dehydration(4);
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
        Invoke("Respawn", 3f);
    }

    void Respawn()
    {
        if (waterVase1 != null)
        {
            waterVase1.ResetWater();
        }
        if (waterVase2 != null)
        {
            waterVase2.ResetWater();
        }
        if (waterVase3 != null)
        {
            waterVase3.ResetWater();
        }
        if (waterVase4 != null)
        {
            waterVase4.ResetWater();
        }
        if (waterVase5 != null)
        {
            waterVase5.ResetWater();
        }
        if (waterVase6 != null)
        {
            waterVase6.ResetWater();
        }
        if (waterVase7 != null)
        {
            waterVase7.ResetWater();
        }

        if(waterPond1 != null)
        {
            waterPond1.ResetWater();
        }
        if (waterPond2 != null)
        {
            waterPond2.ResetWater();
        }
        if (waterPond3 != null)
        {
            waterPond3.ResetWater();
        }
        if (waterPond4 != null)
        {
            waterPond4.ResetWater();
        }
        if (waterPond5 != null)
        {
            waterPond5.ResetWater();
        }
        if (waterPond6 != null)
        {
            waterPond6.ResetWater();
        }
        if (waterPond7 != null)
        {
            waterPond7.ResetWater();
        }
        if (waterPond8 != null)
        {
            waterPond8.ResetWater();
        }
        if (waterPond9 != null)
        {
            waterPond9.ResetWater();
        }
        if (waterPond10 != null)
        {
            waterPond10.ResetWater();
        }
        if (waterPond11 != null)
        {
            waterPond11.ResetWater();
        }

        transition.SetTrigger("End");
        gameObject.tag = "Player";
        transform.position = _spawnPoint;
        _currentThirst = _maxThirst;
        _thirstBar.SetMaxThirst(_maxThirst);
    }
}
