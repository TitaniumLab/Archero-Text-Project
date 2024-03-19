using UnityEngine;

public interface ITrackTargets
{
    public Vector2 GetNearestEnemyPosInRadius(float radius, string layerName);
}
