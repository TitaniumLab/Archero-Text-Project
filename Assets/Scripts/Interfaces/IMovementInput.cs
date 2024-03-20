using UnityEngine;

public interface IMovementInput
{
    public IMovement movement { get; set; }
    public Vector2 MoveDirection();
}
