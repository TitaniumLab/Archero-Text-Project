using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHealth, IDamageable
{
    [SerializeField] private float _maximumHealth = 10;
    [SerializeField] private Vector3 lifeBarOffset = new Vector3(0, -0.4f, 0);
    private Slider slider;
    public float maximumHealth => _maximumHealth;
    private float _health;
    public float health => _health;

    private void Awake()
    {
        _health = _maximumHealth;
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = _maximumHealth;
        slider.value = _health;
    }

    private void LateUpdate()
    {
        slider.transform.rotation = Camera.main.transform.rotation;
        slider.transform.position = transform.position + lifeBarOffset;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
        slider.value = _health;
    }
}
