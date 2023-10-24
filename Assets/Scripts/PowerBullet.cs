using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBullet : MonoBehaviour
{
    private float speed = 8f;
    public Rigidbody2D rb;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
