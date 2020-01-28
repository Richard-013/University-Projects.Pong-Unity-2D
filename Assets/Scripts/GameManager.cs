using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeftCorner;
    public static Vector2 topRightCorner;

    // Start is called before the first frame update
    void Start()
    {
        // Sets bottom left and top right corner vectors
        bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Creates the ball
        Instantiate(ball);

        // Creates the paddles
        Paddle rightPaddle = Instantiate(paddle) as Paddle;
        Paddle leftPaddle = Instantiate(paddle) as Paddle;
        // Runs paddle's set up functions
        rightPaddle.Init(true);
        leftPaddle.Init(false);
    }
}
