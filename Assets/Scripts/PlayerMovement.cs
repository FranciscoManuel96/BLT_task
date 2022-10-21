using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    Vector3 previousLocation;
    Vector3 moveDirection;
    public Transform relativeTransform;

    void Update()
    {
        moveDirection = Vector3.zero;
        previousLocation = transform.position;
        if (Input.GetKey(KeyCode.W)) moveDirection += relativeTransform.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += -relativeTransform.forward;

        moveDirection.y = 0f;

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
    }
}
