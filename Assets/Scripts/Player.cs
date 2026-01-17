using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    float timePressKey;
    float inputMove;
    [SerializeField] Ground ground;

    private void Start()
    {
        timePressKey = 0f;
        inputMove = 0f;
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 deltaPos = new Vector2();
        Vector2 posOfBoundMaxGround = PosOfTopOfColliderGround(ground);

        // Left/right move
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            inputMove = 0.1f;
            inputMove += timePressKey * inputMove;
            deltaPos.x -= inputMove;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            inputMove = 0.1f;
            inputMove += timePressKey * inputMove;
            deltaPos.x += inputMove;
        }

        // Up/down move
        if (Keyboard.current.upArrowKey.isPressed)
        {
            inputMove = 0.1f;
            inputMove += timePressKey * inputMove;
            deltaPos.y += inputMove;
        }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            inputMove = 0.1f;
            inputMove -= timePressKey * inputMove;
            
            if (this.transform.position.y > posOfBoundMaxGround.y + 0.5f)
            {
                deltaPos.y -= inputMove;
            }
        }
        if (Keyboard.current.leftArrowKey.wasReleasedThisFrame || Keyboard.current.rightArrowKey.wasReleasedThisFrame)
        {
            inputMove = 0f;
        }  
        transform.Translate(deltaPos);
    }

    // To take y of bound.max of ground
    Vector2 PosOfTopOfColliderGround(Ground ground)
    {
        Collider2D col = ground.GetComponent<Collider2D>();
        Bounds bound = col.bounds;
        return bound.max;
    }
}
