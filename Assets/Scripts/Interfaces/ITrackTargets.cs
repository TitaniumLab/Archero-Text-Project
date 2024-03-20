using UnityEngine;

public interface ITrackTargets
{
    public string _targetLayerName { get; }
    public Vector2 GetNearestEnemyPosInRadius();
}
