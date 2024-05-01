using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public Vector3 offset = new Vector3(0f, 5f, -10f); // The offset from the target's position

    void LateUpdate()
    {
        if (target != null)
        {
            // Set the camera's position to the target's position plus the offset
            transform.position = target.position + offset;

            // Ensure the camera is always looking at the target
            transform.LookAt(target);
        }
    }
}
