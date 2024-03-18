using UnityEngine;

public class PlayerController : Controller
{
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movement?.Move(new Vector2(horizontalInput, verticalInput));
    }


}
