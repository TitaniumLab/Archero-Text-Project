using UnityEngine;

[RequireComponent(typeof(Controller))]
public class RangeAttackController : MonoBehaviour, IAttackController
{
    [SerializeField] private Transform weaponMountPoint;
    [SerializeField] private Rigidbody2D projectilePrefab;
    [SerializeField] private float projectileSpeed = 100;
    private void Awake()
    {
        GetComponent<Controller>().attackController = this;
    }

    public void AttackBehavior(float damage, float rate, string targetLayerName)
    {
        Rigidbody2D projectile = Instantiate(projectilePrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        projectile.AddForce(projectile.transform.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
