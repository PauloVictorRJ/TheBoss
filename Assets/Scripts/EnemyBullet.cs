using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 velocity;
    private float bounceFactor = 1f;

    void Start()
    {
        velocity = new Vector2(3f, 6f);
        gameObject.name = "EnemyBullet";
    }

    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet" || collision.gameObject.name == "PowerBullet")
        {
            Destroy(gameObject);
        }
        else
        {
            Vector2 reflection = Vector2.Reflect(velocity, collision.contacts[0].normal);

            velocity = reflection.normalized * velocity.magnitude * bounceFactor;
        }
    }
}
