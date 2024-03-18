using UnityEngine;

[RequireComponent(typeof(Controller))]
public class MovementPlayerInput : MonoBehaviour, IMovementInput
{
    private float horizontalInput;
    private float verticalInput;

    private void Awake()
    {
        GetComponent<Controller>().moveInput = this;
    }

    public Vector2 MoveDirection()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        return new Vector2(horizontalInput, verticalInput);
    }
}
