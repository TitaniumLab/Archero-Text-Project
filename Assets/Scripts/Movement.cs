using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IMovementInput))]
public class Movement : MonoBehaviour, IMovement
{
    [SerializeField] private float movementSpeed = 1;
    private Rigidbody2D objRigidbody;


    private void Awake()
    {
        objRigidbody = GetComponent<Rigidbody2D>();
        GetComponent<IMovementInput>().movement = this;
    }

    /// <summary>
    /// move an object 
    /// </summary>
    /// <param name="horizontalInput">x coordinate</param>
    /// <param name="verticalInput">y coordinate</param>
    public void Move(Vector2 direction)
    {
        Vector2 _direction = direction.normalized;
        objRigidbody.velocity = _direction * movementSpeed;
        if (_direction != Vector2.zero)
            transform.up = _direction;
    }
}
