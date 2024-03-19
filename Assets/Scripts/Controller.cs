using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float viewDistance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private string targetLayerName;

    public IMovement movement;
    public IMovementInput moveInput;
    public ITrackTargets trackTargets;
    public IAttackController attackController;

    private void Update()
    {
        Vector2 moveDirection = moveInput != null ? moveInput.MoveDirection() : Vector2.zero;
        Vector2 attackDirection = trackTargets != null ? trackTargets.GetNearestEnemyPosInRadius(viewDistance, targetLayerName) : Vector2.zero;
        movement?.Move(moveDirection, movementSpeed);

        if (moveDirection == Vector2.zero && attackDirection != Vector2.zero)
        {
            transform.up = attackDirection;
            attackController?.AttackBehavior(1, 1, targetLayerName);
        }


    }

    public float GetViewDistance()
    {
        return viewDistance;
    }

    public string GetTargetLayerName()
    {
        return targetLayerName;
    }
}
