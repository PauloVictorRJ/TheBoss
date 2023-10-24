using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon1 : MonoBehaviour
{
    public Transform firePoint1;
    public GameObject bulletPrefab;
    public AudioSource audioSource;
    public AudioClip shootingAudioClip;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        audioSource.PlayOneShot(shootingAudioClip);
    }
}
