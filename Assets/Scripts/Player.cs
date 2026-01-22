using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movement;
    public float speed = 5f;
    public float jumpHeight = 7f;


    public bool isGround = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        movement = SimpleInput.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0f, 0f) * Time.fixedDeltaTime * speed;
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
