using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] float speed = 5f;

    public Vector3 Dir { get; set; }
    public float Damage { get; set; }

    void Update()
    {
        transform.Translate(Dir * (speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IDamageable>()?.TakeDamage(Damage);
        Destroy(gameObject);
    }
}
