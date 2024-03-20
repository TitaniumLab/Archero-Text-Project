using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ITrackTargets))]
public class MovementAI : MonoBehaviour, IMovementInput
{
    [SerializeField] private float fireDistance = 1.5f;

    [SerializeField] private GameObject route;
    private List<Transform> routePoints = new List<Transform>();
    [SerializeField] private int currentPointIndex = 0;
    private bool isWaiting = false;
    public ITrackTargets trackTargets;

    private IMovement Movement;
    public IMovement movement { get => null; set => Movement = value; }


    private void Awake()
    {
        for (int i = 0; i < route.transform.childCount; i++)
            routePoints.Add(route.transform.GetChild(i));

        trackTargets = GetComponent<ITrackTargets>();
    }

    private void FixedUpdate()
    {
        Movement?.Move(MoveDirection());

        if (MoveDirection().magnitude < 0.1f && !isWaiting)
            StartCoroutine(StayOnRoutePoint());
    }

    /// <summary>
    /// Direction of movement
    /// </summary>
    /// <returns>Relative position of the point</returns>
    public Vector2 MoveDirection()
    {
        Vector2 nearestEnemy = trackTargets.GetNearestEnemyPosInRadius();
        if (nearestEnemy != Vector2.zero && nearestEnemy.magnitude > fireDistance)
            return nearestEnemy;
        else if (nearestEnemy != Vector2.zero && nearestEnemy.magnitude < fireDistance)
            return Vector2.zero;
        else if (!isWaiting)
            return GoToPoint();
        else
            return Vector2.zero;
    }

    /// <summary>
    /// Direction to current route point which can see
    /// </summary>
    private Vector2 GoToPoint()
    {
        for (int i = 0; i < routePoints.Count; i++)
        {
            Vector2 direction = routePoints[currentPointIndex].position - transform.position;
            float distance = direction.magnitude;
            RaycastHit2D hit2DObstacle = Physics2D.Raycast(transform.position, direction, distance, 1 << LayerMask.NameToLayer("Obstacle"));
            RaycastHit2D[] hit2DEnemy = Physics2D.RaycastAll(transform.position, direction, distance, 1 << LayerMask.NameToLayer("Enemy"));
            if (!hit2DObstacle && hit2DEnemy.Length < 2)
            {
                return direction;
            }
            else
                currentPointIndex = (currentPointIndex + 1) % routePoints.Count;
        }
        return Vector2.zero;
    }

    /// <summary>
    /// Wait on route point and choose next point
    /// </summary>
    /// <returns></returns>
    private IEnumerator StayOnRoutePoint()
    {
        isWaiting = true;
        float waitSeconds = Random.Range(0, 3f);
        yield return new WaitForSeconds(waitSeconds);
        isWaiting = false;
        currentPointIndex = (currentPointIndex + 1) % routePoints.Count;
    }
}
