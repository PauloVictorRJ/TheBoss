using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Animator anim;
    private float speed = 5f;

    void Start()
    {
        anim = GetComponent<Animator>();
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
            // Intervalo entre -1 e 0
            SetAnimationState(1);
        }
        else if (horizontalInput == -1f)
        {
            // Exatamente -1
            SetAnimationState(2);
        }
        else if (horizontalInput > 0f && horizontalInput < 1f)
        {
            // Intervalo entre 0 e 1
            SetAnimationState(3);
        }
        else if (horizontalInput == 1f)
        {
            // Exatamente 1
            SetAnimationState(4);
        }
        else if (horizontalInput == 0f)
        {
            // Exatamente 0
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
}
