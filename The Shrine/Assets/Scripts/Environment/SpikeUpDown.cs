using UnityEngine;

public class SpikeUpDown : MonoBehaviour
{
    public float movementSpeed = 2f; // Adjust this value to change the speed of movement
    public float movementDistance = 2f; // Adjust this value to change the distance of movement

    private Vector3 originalPosition;
    private bool movingUp = true;
    private float timer = 0f;
    private bool playerInRange = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (playerInRange)
        {
            timer += Time.deltaTime;

            if (timer >= 1.5f)
            {
                movingUp = !movingUp;
                timer = 0f;
            }

            if (movingUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPosition + Vector3.up * movementDistance, movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, movementSpeed * Time.deltaTime);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
