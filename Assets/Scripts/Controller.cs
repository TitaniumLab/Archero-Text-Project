using UnityEngine;

public class Controller : MonoBehaviour
{
    public IMovement movement;
    public IMovementInput moveInput;

    private void Update()
    {
        Vector2 moveDirection = moveInput != null ? moveInput.MoveDirection() : Vector2.zero;
        movement?.Move(moveDirection);
    }
}
