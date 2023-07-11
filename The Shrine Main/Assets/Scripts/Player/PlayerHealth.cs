using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerHealth : MonoBehaviour
{
    public float _maxThirst = 100;
    public float _currentThirst;
    public Animator _screenAnimator;
    public Animator _playerAnimator;

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
        if (collision.gameObject.CompareTag("Obstacles") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Dehydration()
    {
        _currentThirst -= 1 * Time.deltaTime;
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
        _playerAnimator.SetBool("Dead", true);
        Invoke("FadeOut", 1);
        Invoke("Respawn", 3);
    }

    void Respawn()
    {
        Invoke("FadeIn", 1);
        gameObject.tag = "Player";
        _playerAnimator.SetBool("Dead", false);
        transform.position = _spawnPoint;
        _currentThirst = _maxThirst;
        _thirstBar.SetMaxThirst(_maxThirst);
    }

    void FadeOut()
    {
        _screenAnimator.SetBool("FadeOut", true);
    }

    void FadeIn()
    {
        _screenAnimator.SetBool("FadeOut", false);
    }
}
