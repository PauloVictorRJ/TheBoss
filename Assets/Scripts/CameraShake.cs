using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeDuration = 0.2f; // Duração do tremor
    private float shakeAmount = 0.1f; // Intensidade do tremor
    private float decreaseFactor = 0.01f; // Quão rápido o tremor diminuirá

    private Vector3 originalPosition;

    void Update()
    {
        if (Input.GetButtonDown("Fire2")) // Ou qualquer condição que você deseje para o tiro da nave
        {
            originalPosition = transform.position;
            InvokeRepeating("StartShake", 0f, 0.01f);
            Invoke("StopShake", shakeDuration);
        }
    }

    void StartShake()
    {
        float offsetX = Random.Range(-1f, 1f) * shakeAmount;
        float offsetY = Random.Range(-1f, 1f) * shakeAmount;
        transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        transform.position = originalPosition;
    }
}
