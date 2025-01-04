using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] float speed = 5f;

    public Vector3 Dir { get; set; }

    void Update()
    {
        transform.Translate(Dir * (speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
