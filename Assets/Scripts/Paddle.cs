using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;
    string input;
    [HideInInspector]
    public bool isRightPaddle;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRight)
    {
        isRightPaddle = isRight;
        Vector2 newPosition = Vector2.zero;

        if(isRightPaddle)
        {
            // Paddle is placed on the right-side of the screen
            newPosition = new Vector2(GameManager.topRightCorner.x, 0); // Sets position as the far right of the screen
            newPosition -= Vector2.right * transform.localScale.x; // Adds an offset equal to the width of the paddle

            input = "PaddleRight"; // Sets input controller
        }
        else
        {
            // Paddle is placed on the left-side of the screen
            newPosition = new Vector2(GameManager.bottomLeftCorner.x, 0); // Sets position as the far left of the screen
            newPosition += Vector2.right * transform.localScale.x; // Adds an offset equal to the width of the paddle

            input = "PaddleLeft"; // Sets input controller
        }

        transform.position = newPosition;
        transform.name = input; // Sets the paddle's name in the hierarchy
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed; // Time.deltaTime makes the movement speed framerate independent

        // Prevent paddle leaving the screen
        if(transform.position.y < (GameManager.bottomLeftCorner.y + height/2) && move < 0)
        {
            // If current paddle position is less than the bottom of the screen plus half the height of the paddle, prevent downward movement
            move = 0;
        }
        if(transform.position.y > (GameManager.topRightCorner.y - height/2) && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up); // Converts move into actual movement
    }
}
