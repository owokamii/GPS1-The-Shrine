using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float maxY = 10f; // Maximum Y position

    private Vector3 initialPosition; // Initial camera position
    private bool isMovingCamera = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    // Call this method to smoothly transition the camera to the target position
    private IEnumerator MoveCamera(Vector3 targetPosition)
    {
        isMovingCamera = true;
        float t = 0f;
        Vector3 startPosition = transform.position;

        while (t < 1f)
        {
            t += Time.deltaTime * followSpeed;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        isMovingCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);

        if (newPos.y > maxY)
        {
            newPos.y = maxY;
        }

        if (target.position.y < maxY && !isMovingCamera)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }

    // Call this method to reset the camera position after the player respawns
    public void ResetCameraPosition()
    {
        StartCoroutine(MoveCamera(initialPosition));
    }
}
