using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Controller
{
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector2(horizontalInput, verticalInput);
        movement?.Move(moveDirection);
    }


}
