using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    //[SerializeField] float speedOfPlayer;
    float timePressKey;
    float inputMoveX;

    private void Update()
    {
        MovePlayer();
    }

    private void Start()
    {
        timePressKey = 0f;
        inputMoveX = 0f;
    }

    void MovePlayer()
    {
        Vector2 deltaPos = new Vector2();
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            inputMoveX = 0.1f;
            inputMoveX += timePressKey * inputMoveX;
            deltaPos.x -= inputMoveX;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            inputMoveX = 0.1f;
            inputMoveX += timePressKey * inputMoveX;
            deltaPos.x += inputMoveX;
        }
        if (Keyboard.current.leftArrowKey.wasReleasedThisFrame || Keyboard.current.rightArrowKey.wasReleasedThisFrame)
        {
            inputMoveX = 0f;
        }  
        transform.Translate(deltaPos);
    }
}
