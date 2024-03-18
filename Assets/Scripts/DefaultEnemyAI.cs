using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject route;
    private List<Transform> routePoints = new List<Transform>();



    private void Start()
    {
        float distance = 100;
        InvokeRepeating("StartAI", 0, 2);
        for (int i = 0; i < route.transform.childCount; i++)
        {
            float _distance = (route.transform.GetChild(i).position - transform.position).magnitude;
            routePoints.Add(route.transform.GetChild(i));
            if (_distance < distance)
            {
                distance = _distance;
                currentPoint = i;
            }
        }
        GoToNextPoint();


    }
    int currentPoint;


    private void StartAI()
    {

    }


    private void GoToNextPoint()
    {
        destinationPoint = routePoints[currentPoint].position;

    }
}
