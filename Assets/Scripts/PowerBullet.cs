using UnityEngine;

public class PowerBullet : MonoBehaviour
{
    private float speed = 18f;
    public Rigidbody2D rb;
    private CameraTremor cameraTremor;
    public GameObject HitSplashPrefab2;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        rb.velocity = transform.right * speed;
        cameraTremor = Camera.main.GetComponent<CameraTremor>();
        gameObject.name = "PowerBullet";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HitSplash2 explosion = collision.gameObject.GetComponent<HitSplash2>();

        if (collision.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
            cameraTremor.IniciarTremor();
            Instantiate(HitSplashPrefab2, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.name == "Scenario" || collision.gameObject.name == "EnemyBullet")
        {
            Destroy(gameObject);
            Instantiate(HitSplashPrefab2, transform.position, Quaternion.identity);
        }
    }
}
