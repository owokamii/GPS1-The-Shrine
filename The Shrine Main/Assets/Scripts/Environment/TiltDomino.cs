using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltDomino : MonoBehaviour
{
    private float fallDelay = 2f;
    private float destroyDelay = 5f;
    private Quaternion initialRotation; // Store the initial rotation of the platform
    private bool isFalling = false; // Flag to check if the platform is already falling
    private Animator animator;
    public AudioSource crackSoundEffect;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float tiltAngle = 30f; // Set the desired tilt angle
    [SerializeField] private Transform lowerPosition; // Reference to the transform representing the lower position

    Vector2 _spawnPoint;

    void Start()
    {
        _spawnPoint = transform.position;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        initialRotation = transform.rotation; // Store the initial rotation
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            animator.SetTrigger("Stepped");
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(Tilt());
        crackSoundEffect.Play();

        float elapsedTime = 0f;
        Vector2 initialPosition = transform.position;
        Vector2 targetPosition = lowerPosition.position;

        while (elapsedTime < destroyDelay)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / destroyDelay; // Calculate the interpolation factor

            // Interpolate the position towards the target lower position
            transform.position = Vector2.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f); // Add a small delay before respawning
        Respawn();
    }

    private IEnumerator Tilt()
    {
        float elapsedTime = 0f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, tiltAngle); // Calculate the target tilt rotation

        while (elapsedTime < destroyDelay)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / destroyDelay; // Calculate the interpolation factor

            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t); // Interpolate the rotation towards the target tilt rotation
            yield return null;
        }
    }

    void Respawn()
    {
        Debug.Log("Pillars respawn");
        transform.position = _spawnPoint;
        rb.bodyType = RigidbodyType2D.Static;
        transform.rotation = initialRotation;
        isFalling = false;
    }
}
