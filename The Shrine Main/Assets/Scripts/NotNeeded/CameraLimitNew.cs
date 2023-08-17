using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimitNew : MonoBehaviour
{
    public Transform target;  // The player's transform
    public float maxYPosition = 5f;  // Maximum y position for the camera

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;  // Maintain camera's original z position

        // Limit the y position of the target to the maximum value
        targetPosition.y = Mathf.Clamp(targetPosition.y, transform.position.y, maxYPosition);

        transform.position = targetPosition;
    }
}
