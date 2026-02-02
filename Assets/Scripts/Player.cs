using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movement;
    public float speed = 5f;
    public float jumpHeight = 7f;


    public bool isGround = true;
    public bool facingRight = true;

    public Animator animator;

    private void Start()
    {
        
    }

    private void Update()
    {
        movement = SimpleInput.GetAxis("Horizontal");

        // set run value equal movement
        animator.SetFloat("Run", Mathf.Abs(movement));

        if (movement < 0f && facingRight)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facingRight = false;
        }

        if (movement > 0f && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;
        }

        if (animator.GetFloat("Run") > 0.1f)
        {
            animator.SetFloat("Run", 1f);
        }else if (animator.GetFloat("Run") < 0.1f)
        {
            animator.SetFloat("Run", 0f);
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0f, 0f) * Time.fixedDeltaTime * speed;
    }

    public void PlayerAttackAnimation()
    {
        float random = Random.Range(0, 3);

        if (random == 0)
        {
            animator.SetTrigger("Attack1");
        }
        else if (random == 1)
        {
            animator.SetTrigger("Attack2");
        }
        else
        {
            animator.SetTrigger("Attack3");
        }
    }

    public void JumpButton()
    {
        if (isGround)
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.y = jumpHeight;
            rb.linearVelocity = velocity;
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGround = true;
        }
    }


}
