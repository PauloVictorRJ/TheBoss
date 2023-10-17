using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2d(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

}
