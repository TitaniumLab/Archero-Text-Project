using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
[RequireComponent(typeof(ITrackTargets))]
public class MovementAI : MonoBehaviour, IMovementInput
{
    [SerializeField] private GameObject route;
    [SerializeField] private float fireDistance = 1.5f;
    private string targetLayerName;
    private float viewDistance;
    private List<Vector3> routePoints = new List<Vector3>();
    private int currentPoint;
    private bool isWaiting = false;
    public ITrackTargets trackTargets;

    private void Awake()
    {
        SetNearestRoutePoint();
        GetComponent<Controller>().moveInput = this;
        this.viewDistance = GetComponent<Controller>().GetViewDistance();
        this.targetLayerName = GetComponent<Controller>().GetTargetLayerName();
        trackTargets = GetComponent<ITrackTargets>();
    }

    private void FixedUpdate()
    {
        if (MoveDirection().magnitude < 0.1f && !isWaiting)
            StartCoroutine(StayOnRoutePoint());
    }

    /// <summary>
    /// Direction of movement
    /// </summary>
    /// <returns>Relative position of the point</returns>
    public Vector2 MoveDirection()
    {
        Vector2 nearestEnemy = trackTargets.GetNearestEnemyPosInRadius(viewDistance, targetLayerName);
        if (nearestEnemy != Vector2.zero && nearestEnemy.magnitude > fireDistance)
            return nearestEnemy;
        else if (nearestEnemy != Vector2.zero && nearestEnemy.magnitude < fireDistance)
            return Vector2.zero;
        if (!isWaiting)
            return routePoints[currentPoint] - transform.position;
        else
            return Vector2.zero;
    }

    /// <summary>
    /// Finds index of nearest point to start route
    /// </summary>
    private void SetNearestRoutePoint()
    {
        float distance = 100;
        for (int i = 0; i < route.transform.childCount; i++)
        {
            float _distance = (route.transform.GetChild(i).position - transform.position).magnitude;
            routePoints.Add(route.transform.GetChild(i).position);
            if (_distance < distance)
            {
                distance = _distance;
                currentPoint = i;
            }
        }
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
        currentPoint = (currentPoint + 1) % routePoints.Count;
    }
}
