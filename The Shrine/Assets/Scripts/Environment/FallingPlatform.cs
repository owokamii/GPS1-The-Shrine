using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.5f;
    private float destroyDelay = 2f;
    private Quaternion initialRotation; // Store the initial rotation of the platform
    private bool isFalling = false; // Flag to check if the platform is already falling

    Vector2 _spawnPoint;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float tiltAngle = 30f; // Set the desired tilt angle

    void Start()
    {
        _spawnPoint = transform.position;
    }

    private void Awake()
    {
        initialRotation = transform.rotation; // Store the initial rotation
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(Tilt());
        yield return new WaitForSeconds(destroyDelay);
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
        Debug.Log("Platform respawn");
        transform.position = _spawnPoint;
        rb.bodyType = RigidbodyType2D.Static;
        transform.rotation = initialRotation;
        isFalling = false;
    }
}
