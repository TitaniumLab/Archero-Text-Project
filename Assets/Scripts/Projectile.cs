using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string enemyLayerName;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Projectile"))
        {
            IDamageable doDamage = collision.GetComponent<IDamageable>();
            if (doDamage != null && collision.CompareTag(enemyLayerName))
            {
                doDamage.TakeDamage(damage);

            }
            Destroy(gameObject);
        }
    }
}
