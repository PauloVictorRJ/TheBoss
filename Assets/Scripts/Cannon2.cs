using System.Collections;
using UnityEngine;

public class Cannon2 : MonoBehaviour
{
    public Transform firePoint2;
    public GameObject powerBulletPrefab;
    public AudioSource audioSource;
    public AudioClip shootingAudioClip;

    private bool canShoot = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && canShoot)
        {
            StartCoroutine(ShootWithCooldown());
        }
    }

    IEnumerator ShootWithCooldown()
    {
        canShoot = false;

        Instantiate(powerBulletPrefab, firePoint2.position, firePoint2.rotation);
        audioSource.PlayOneShot(shootingAudioClip);

        yield return new WaitForSeconds(3f);

        canShoot = true;
    }
}
