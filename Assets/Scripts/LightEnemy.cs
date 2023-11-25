using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightEnemy : MonoBehaviour
{
    public Transform player1;
    public Light2D luz;
    public Transform enemy;

    void Start()
    {
        luz = GetComponent<Light2D>();
    }

    void Update()
    {
        Vector3 direcaoParaPlayer = player1.position - enemy.position;

        float angulo = Mathf.Atan2(direcaoParaPlayer.y, direcaoParaPlayer.x) * Mathf.Rad2Deg;

        angulo += 270f;

        luz.transform.rotation = Quaternion.Euler(0f, 0f, angulo);

        luz.transform.position = enemy.position;
    }
}
