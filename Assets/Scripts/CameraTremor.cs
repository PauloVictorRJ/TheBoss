using UnityEngine;

public class CameraTremor : MonoBehaviour
{
    private Vector3 originalPosition;
    private float tremorIntensidade = 0.2f;
    private float tremorDuracao = 0.4f;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void IniciarTremor()
    {
        InvokeRepeating("Tremor", 0f, 0.01f);
        Invoke("PararTremor", tremorDuracao);
    }

    void Tremor()
    {
        float offsetX = Random.Range(-tremorIntensidade, tremorIntensidade);
        float offsetY = Random.Range(-tremorIntensidade, tremorIntensidade);
        transform.position = originalPosition + new Vector3(offsetX, offsetY, originalPosition.z);
    }

    void PararTremor()
    {
        CancelInvoke("Tremor");
        transform.position = originalPosition;
    }
}
