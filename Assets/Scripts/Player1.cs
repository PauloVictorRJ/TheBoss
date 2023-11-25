using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Animator anim;
    private float speed = 8f;
    public AudioSource audioSource;
    public AudioClip DeathAudioClip;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.name = "Player 1";
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput < 0f && horizontalInput > -1f)
        {
            SetAnimationState(1);
        }
        else if (horizontalInput == -1f)
        {
            SetAnimationState(2);
        }
        else if (horizontalInput > 0f && horizontalInput < 1f)
        {
            SetAnimationState(3);
        }
        else if (horizontalInput == 1f)
        {
            SetAnimationState(4);
        }
        else if (horizontalInput == 0f)
        {
            SetAnimationState(0);
        }

        Move(horizontalInput, verticalInput);
    }

    void Move(float horizontalInput, float verticalInput)
    {
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += movement * speed * Time.deltaTime;
    }

    void SetAnimationState(int state)
    {
        anim.SetInteger("p1State", state);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            anim.SetInteger("p1State", 5);
            audioSource.PlayOneShot(DeathAudioClip);
        }

        if (collision.gameObject.name == "EnemyBullet")
        {
            anim.SetInteger("p1State", 5);
            audioSource.PlayOneShot(DeathAudioClip);
        }
    }
}
