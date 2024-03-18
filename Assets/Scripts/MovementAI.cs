using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class MovementAI : MonoBehaviour, IMovementInput
{
    [SerializeField] private GameObject route;
    private List<Vector3> routePoints = new List<Vector3>();
    private int currentPoint;
    private bool isWaiting = false;

    private void Awake()
    {
        SetNearestRoutePoint();
        GetComponent<Controller>().moveInput = this;
    }

    private void FixedUpdate()
    {
        if (MoveDirection().magnitude < 0.1f && !isWaiting)
            StartCoroutine(StayOnRoutePoint());
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
    /// Direction of movement
    /// </summary>
    /// <returns>Relative position of the point</returns>
    public Vector2 MoveDirection()
    {
        if (!isWaiting)
        {
            return routePoints[currentPoint] - transform.position;
        }
        else
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
        currentPoint = (currentPoint + 1) % routePoints.Count;
    }
}
