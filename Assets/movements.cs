using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float vitesse = 5f;
    public float rotationSpeed = 200f;
    public float jumpHeight = 5f;
    public Rigidbody propphys;
    private Vector3 direction;
    public Transform cameraTransform; // Reference to the camera

    void Start()
    {
        if (propphys == null)
        {
            propphys = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");  // Left & Right movement
        float moveZ = Input.GetAxis("Vertical");    // Forward & Backward movement

        // Calculate movement relative to the camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;  // Ignore vertical tilt of the camera
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Move relative to the camera
        direction = forward * moveZ + right * moveX;
        direction.Normalize();

        // Rotate the character to face movement direction
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Jump logic
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            propphys.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        // Move the character in the rotated direction
        propphys.MovePosition(transform.position + direction * vitesse * Time.fixedDeltaTime);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
