using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon2 : MonoBehaviour
{
    public Transform firePoint2;
    public GameObject powerBulletPrefab;
    public AudioSource audioSource;
    public AudioClip shootingAudioClip;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(powerBulletPrefab, firePoint2.position, firePoint2.rotation);
        audioSource.PlayOneShot(shootingAudioClip);
    }
}

