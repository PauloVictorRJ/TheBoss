using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public Rigidbody2D rb;
    public GameObject HitSplashPrefab;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        rb.velocity = transform.right * speed;
        gameObject.name = "Bullet";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        HitSplash explosion = collision.gameObject.GetComponent<HitSplash>();
        Instantiate(HitSplashPrefab, transform.position, Quaternion.identity);
    }
}
