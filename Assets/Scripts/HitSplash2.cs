using UnityEngine;

public class HitSplash2 : MonoBehaviour
{
    private float explosionDuration = 2f;

    void Start()
    {
        Destroy(gameObject, explosionDuration);
    }
}
