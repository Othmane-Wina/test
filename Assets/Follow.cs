using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -5);
    public float smoothSpeed = 5f;
    public float rotationSpeed = 100f; // Speed of camera rotation

    void LateUpdate()
    {
        if (target != null)
        {
            // Rotate the camera with right mouse button
            if (Input.GetMouseButton(1)) // Right-click to rotate
            {
                float horizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                transform.RotateAround(target.position, Vector3.up, horizontal);
            }

            // Keep the camera behind the player
            Vector3 desiredPosition = target.position + transform.rotation * offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Ensure the camera always looks at the player
            transform.LookAt(target);
        }
    }
}
