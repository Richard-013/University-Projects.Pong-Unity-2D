using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // Sets direction to (1,1) normalized because by default one uses the square root of 2
        radius = transform.localScale.x / 2; // Radius is half the width (diameter)
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Invert y direction when top or bottom of screen is encountered
        if(transform.position.y < (GameManager.bottomLeftCorner.y + radius) && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if(transform.position.y > (GameManager.topRightCorner.y - radius) && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        // Win Condition - Out of bounds on x-axis
        if(transform.position.x < (GameManager.bottomLeftCorner.x + radius) && direction.x < 0)
        {
            // Right Player Wins - Out of Bounds on the Left
            Debug.Log("Player 2 Wins");
            SceneManager.LoadScene("Scenes/Player2Win");
            //Time.timeScale = 0;
        }
        if(transform.position.x > (GameManager.topRightCorner.x - radius) && direction.x > 0)
        {
            // Left Player Wins - Out of Bounds on the Right
            Debug.Log("Player 1 Wins");
            SceneManager.LoadScene("Scenes/Player1Win");
            //Time.timeScale = 0;
        }
    }

    // Paddle Collision
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.tag == "Paddle")
        {
            bool isRightPaddle = otherObject.GetComponent<Paddle>().isRightPaddle;
            if(isRightPaddle == true && direction.x > 0)
            {
                // If right paddle is hit and ball is moving towards the right, invert x direction
                direction.x = -direction.x;
            }
            if(isRightPaddle == false && direction.x < 0)
            {
                // If left paddle is hit and ball is moving towards the left, invert x direction
                direction.x = -direction.x;
            }
        }
    }
}
