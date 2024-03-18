using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Controller))]
public class Movement : MonoBehaviour, IMovement
{
    private Rigidbody2D objRigidbody;
    [SerializeField] private float movSpeed = 1;

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
        objRigidbody.velocity = _direction * movSpeed;
        if (_direction != Vector2.zero)
            transform.up = _direction;
    }
}
