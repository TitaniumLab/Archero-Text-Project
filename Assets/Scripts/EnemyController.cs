using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyController : Controller
{
    Vector2 destinationPoint;

    private void Start()
    {
        InvokeRepeating("StartAI", 0, 5);
    }

    private void FixedUpdate()
    {
        float remainingDistance = (destinationPoint - new Vector2(transform.position.x, transform.position.y)).magnitude;

        if (remainingDistance > 0.2f)
            movement?.Move(destinationPoint - new Vector2(transform.position.x, transform.position.y));
        else
            movement?.Move(Vector2.zero);

    }

    private void StartAI()
    {
        destinationPoint = GetDestinationPoint();
        Debug.Log(destinationPoint);
    }



    private Vector2 GetDestinationPoint()
    {
        while (true)
        {
            horizontalInput = Random.Range(0, 1f);
            verticalInput = Random.Range(0, 1f);
            float distance = Random.Range(1, 5f);
            Vector2 direction = new Vector2(horizontalInput + transform.position.x, verticalInput + transform.position.y).normalized * distance;



            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, direction, distance);
            if (hit.Length < 2)
            {

                if (Physics2D.OverlapCircle(direction, 0.3f) == null)
                {
                    return direction;
                }

            }
        }
    }

    //private IEnumerator Activation()
    //{
    //    horizontalInput = Random.Range(-1f, 1f);
    //    verticalInput = Random.Range(-1f, 1f);
    //    yield return new WaitForSeconds(1);
    //}

}
