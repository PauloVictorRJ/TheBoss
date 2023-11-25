using UnityEngine;

public class MovimentacaoInimigo : MonoBehaviour
{
    public Transform player1;
    private float velocidadeX = 7f;
    private float velocidadeY = 1f;
    private float intervaloMinMudancaDirecao = 1f;
    private float intervaloMaxMudancaDirecao = 3f;
    private float raioMovimentoAleatorioX = 10f;
    private float variacaoAleatoriaY = 0.2f;
    private int direcaoX = 1;
    private int direcaoY = 1;
    private float tempoProximaMudancaDirecao;
    private bool bateuEmColisor = false;
    public Placar placarScript;
    public AudioSource audioSource;
    public AudioClip enemyHit;
    private float maxDistance = 18f;
    private float maxVolume = 1f;
    public GameObject enemyBulletPrefab;
    private float tempoProximoLancamentoBullet;
    private float intervaloLancamentoMin = 1f;
    private float intervaloLancamentoMax = 3f;

    void Start()
    {
        DefinirProximaMudancaDirecao();
        gameObject.name = "Enemy";
        audioSource.clip = GetComponent<AudioSource>().clip;
    }

    void Update()
    {
        Vector3 directionToPlayer = player1.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        directionToPlayer.Normalize();

        float volume = 1f - Mathf.Clamp01(distanceToPlayer / maxDistance);
        audioSource.volume = volume * maxVolume;

        audioSource.panStereo = -Mathf.Clamp(directionToPlayer.x, -1f, 1f);

        if (!bateuEmColisor && Time.time > tempoProximaMudancaDirecao)
        {
            direcaoX = Random.Range(0, 2) * 2 - 1;
            direcaoY = Random.Range(0, 2) * 2 - 1;
            DefinirProximaMudancaDirecao();
        }

        float movimentoY = Mathf.Clamp((Random.Range(-variacaoAleatoriaY, variacaoAleatoriaY) + velocidadeY) * direcaoY * Time.deltaTime, -0.5f, 0.5f);
        float movimentoX = direcaoX * velocidadeX * Time.deltaTime;

        Vector3 posicao = transform.position;
        posicao.x = Mathf.Clamp(posicao.x + movimentoX, -raioMovimentoAleatorioX, raioMovimentoAleatorioX);
        posicao.y = Mathf.Clamp(posicao.y + movimentoY, 0, Screen.height / 2);

        transform.position = posicao;

        if (Time.time > tempoProximoLancamentoBullet)
        {
            LancarBullet();
            tempoProximoLancamentoBullet = Time.time + Random.Range(intervaloLancamentoMin, intervaloLancamentoMax);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bullet")
        {
            audioSource.PlayOneShot(enemyHit);
            placarScript.IncrementarPlacar(5);
        }

        if (other.name == "PowerBullet")
        {
            placarScript.IncrementarPlacar(100);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            audioSource.PlayOneShot(enemyHit);
            placarScript.IncrementarPlacar(5);
        }

        if (collision.gameObject.name == "PowerBullet")
        {
            placarScript.IncrementarPlacar(100);
        }

        if (collision.gameObject.name == "Scenario")
        {
            direcaoY *= -1;
            direcaoX *= -1;
            bateuEmColisor = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Scenario")
        {
            bateuEmColisor = false;
        }
    }

    void DefinirProximaMudancaDirecao()
    {
        tempoProximaMudancaDirecao = Time.time + Random.Range(intervaloMinMudancaDirecao, intervaloMaxMudancaDirecao);
    }

    void LancarBullet()
    {
        int qtdBullet = Random.Range(1, 3);
        for (int i = 0; i < qtdBullet; i++)
        {
            launchBullet();
        }
    }

    void launchBullet()
    {
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }
}
