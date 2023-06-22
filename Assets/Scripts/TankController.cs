using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.5f;
    private float rotationSpeed = 60f;

    private Rigidbody rb;
    private Vector2 movementAxis;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementAxis();
    }
    void FixedUpdate()
    {
        UpdatePosition();
        UpdateRotation();
    }
    void UpdateMovementAxis()
    {
        movementAxis.x = Input.GetAxis("Horizontal");
        movementAxis.y = Input.GetAxis("Vertical");
    }
    void UpdatePosition()
    {
        var movementPosition = transform.forward * (movementAxis.y * moveSpeed * Time.deltaTime);
        var currentPosition = rb.position;
        var newPosition = currentPosition + movementPosition;
        rb.MovePosition(newPosition);
    }
    void UpdateRotation()
    {
        var rotationMovement = movementAxis.x * rotationSpeed * Time.deltaTime;
        var currentRotation = rb.rotation.eulerAngles;
        currentRotation.y += rotationMovement;

        var newRotation = Quaternion.Euler(currentRotation);
        rb.MoveRotation(newRotation);
    }

    public void Move(Vector2 newMovementAxis)
    {
        movementAxis = newMovementAxis;
    }
}
