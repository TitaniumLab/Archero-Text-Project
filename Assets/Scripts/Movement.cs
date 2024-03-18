using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Controller))]
public class Movement : MonoBehaviour, IMovement
{
    private Rigidbody2D objRigidbody;

    private void Awake()
    {
        objRigidbody = GetComponent<Rigidbody2D>();
        GetComponent<Controller>().movement = this;
    }

    /// <summary>
    /// move an object using 2 coordinates
    /// </summary>
    /// <param name="horizontalInput">x coordinate</param>
    /// <param name="verticalInput">y coordinate</param>
    public void Move(Vector2 direction)
    {
        Vector2 _direction = direction.normalized;
        objRigidbody.velocity = direction * 1;
        if (direction != Vector2.zero)
            transform.up = direction;
    }
}
