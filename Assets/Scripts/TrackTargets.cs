using UnityEngine;

public class TrackTargets : MonoBehaviour, ITrackTargets
{
    [SerializeField] private string targetLayerName;
    public string _targetLayerName { get { return targetLayerName; } }

    [SerializeField] private float viewDistance;

    /// <summary>
    /// Returns nearest collider2d
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="layerName"></param>
    /// <returns></returns>
    public Vector2 GetNearestEnemyPosInRadius()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, viewDistance, 1 << LayerMask.NameToLayer(targetLayerName));
        Vector2 direction = Vector2.zero;
        float distance = viewDistance;

        if (colliders.Length == 0)
            return Vector2.zero;
        else
            for (int i = 0; i < colliders.Length; i++)
            {
                Vector2 _direction = colliders[i].transform.position - transform.position;
                float _distance = _direction.magnitude;
                RaycastHit2D hit2D = Physics2D.Raycast(transform.position, _direction, _distance, 1 << LayerMask.NameToLayer("Obstacle"));
                if (_distance < distance && !hit2D)
                {
                    distance = _distance;
                    direction = _direction;
                }
            }

        return direction;
    }

}