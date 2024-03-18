using UnityEngine;

public class EnemyController : Controller
{


    private void FixedUpdate()
    {
        horizontalInput = destinationPoint.x - transform.position.x;
        verticalInput = destinationPoint.y - transform.position.y;

        float remainingDistance = new Vector2(horizontalInput, verticalInput).magnitude;


        if (remainingDistance > 0.1f)
        {
            movement?.Move(horizontalInput, verticalInput);

        }

        else
        {

            movement?.Move(0, 0);
            currentPoint = (currentPoint + 1) % routePoints.Count;
            GoToNextPoint();
        }


    }

    //private Vector2 GetDestinationPoint()
    //{
    //    //int i = 0;
    //    //while (true)
    //    //{
    //    //    float xPoint = Random.Range(leftBound.position.x + 0.5f, rightBound.position.x - 0.5f);
    //    //    float yPoint = Random.Range(lowerBound.position.y + 0.5f, upperBound.position.y - 0.5f);

    //    //    Vector2 destination = new Vector2(xPoint, yPoint);
    //    //    Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
    //    //    Vector2 direction = startPos - destination;
    //    //    float distance = destination.magnitude;
    //    //    i++;

    //    //    RaycastHit2D[] hit = Physics2D.RaycastAll(destination, direction, distance - 0.5f);
    //    //    if (hit.Length == 1)
    //    //    {
    //    //        //Debug.Log(hit.Length);
    //    //        if (Physics2D.OverlapCircle(destination, 0.4f) == null)
    //    //        {
    //    //            Debug.Log(destination);
    //    //            Debug.Log(i);
    //    //            return destination;
    //    //        }

    //    //    }
    //    //}
    //}

    //private IEnumerator Activation()
    //{
    //    horizontalInput = Random.Range(-1f, 1f);
    //    verticalInput = Random.Range(-1f, 1f);
    //    yield return new WaitForSeconds(1);
    //}

}
