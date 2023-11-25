using UnityEngine;

public class HitSplash : MonoBehaviour
{
    private float explosionDuration = 1f;

    void Start()
    {
        Destroy(gameObject, explosionDuration);
    }
}
