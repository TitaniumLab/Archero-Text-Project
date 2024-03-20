using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ITrackTargets))]
public class RangeAttackController : MonoBehaviour, IAttackController
{
    [SerializeField] private Transform weaponMountPoint;
    [SerializeField] private Rigidbody2D projectilePrefab;
    private Rigidbody2D objRb;
    [SerializeField] private float damage = 1;
    [SerializeField] private float attackRate = 1;
    [SerializeField] private float projectileSpeed = 10;
    private bool reload = false;
    private ITrackTargets trackTargets;

    private void Awake()
    {
        objRb = GetComponent<Rigidbody2D>();
        trackTargets = GetComponent<ITrackTargets>();
    }

    private void FixedUpdate()
    {
        Vector2 targetPos = trackTargets.GetNearestEnemyPosInRadius();
        if (objRb.velocity == Vector2.zero && targetPos != Vector2.zero)
        {
            transform.up = targetPos;
            if (!reload)
            {
                AttackBehavior();
            }
        }
    }

    public void AttackBehavior()
    {
        Rigidbody2D projectile = Instantiate(projectilePrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        projectile.AddForce(projectile.transform.up * projectileSpeed, ForceMode2D.Impulse);
        Projectile projScript = projectile.GetComponent<Projectile>();
        projScript.enemyLayerName = trackTargets._targetLayerName;
        projScript.damage = damage;
        reload = true;
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1 / attackRate);
        reload = false;
    }
}
