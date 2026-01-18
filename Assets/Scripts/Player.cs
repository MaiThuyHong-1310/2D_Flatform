using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    float timePressKey;
    float inputMove;
    [SerializeField] Ground ground;
    [SerializeField] InputActionAsset inputMoveAction;
    InputAction inputMoveActionReference;

    private void OnEnable()
    {
        inputMoveActionReference = inputMoveAction.FindAction("Player/Move", true);
        inputMoveActionReference.Enable();
    }


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

        Vector2 inputValue = inputMoveActionReference.ReadValue<Vector2>();

        // Left/right move
        if (inputValue.x < 0)
        {
            inputMove = 0.1f;
            inputMove += timePressKey * inputMove;
            deltaPos.x -= inputMove;
        }
        if (inputValue.x > 0)
        {
            inputMove = 0.1f;
            inputMove += timePressKey * inputMove;
            deltaPos.x += inputMove;
        }

        // Up/down move
        if (inputValue.y > 0)
        {
            inputMove = 0.1f;
            inputMove += timePressKey * inputMove;
            deltaPos.y += inputMove;
        }

        if (inputValue.y < 0)
        {
            inputMove = 0.1f;
            inputMove -= timePressKey * inputMove;
            
            if (this.transform.position.y > posOfBoundMaxGround.y + 0.5f)
            {
                deltaPos.y -= inputMove;
            }
        }
        if (inputValue.x == 0 && inputValue.y == 0)
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

    private void OnDisable()
    {
        inputMoveActionReference.Disable();
    }
}
