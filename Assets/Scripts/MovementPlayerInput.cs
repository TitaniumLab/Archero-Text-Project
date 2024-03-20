using System;
using UnityEngine;


public class MovementPlayerInput : MonoBehaviour, IMovementInput
{
    private float horizontalInput;
    private float verticalInput;
    private IMovement Movement;
    public IMovement movement { get => null; set => Movement = value; }

    private void Update()
    {
        Vector2 moveDirection = MoveDirection();
        Movement?.Move(moveDirection);
    }

    public Vector2 MoveDirection()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        return new Vector2(horizontalInput, verticalInput);
    }
}
