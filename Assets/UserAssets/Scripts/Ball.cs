using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndGameNamespace;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;
    float radius;

    Vector2 originalPos;
    Vector2 direction;
    Paddle leftPaddle;
    Paddle rightPaddle;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; // direction is (1,1) normalized
        radius = transform.localScale.x / 2; // half the width
        originalPos = transform.position;
    }

    void EndGame(Paddle paddle)
    {
        if (paddle.isRight)
        {
            Debug.Log("Right player wins!!");
            EndGameNamespace.EndGame.textString = "Right Player Wins !!";
        }
        else
        {
            Debug.Log("Left player wins!!");
            EndGameNamespace.EndGame.textString = "Left Player Wins !!";
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if ((transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) || (transform.position.y > GameManager.topRight.y - radius && direction.y > 0))
        {
            direction.y = -direction.y;
        }

        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            IncreaseScore(rightPaddle);
        }

        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            IncreaseScore(leftPaddle);
        }

    }

    public void Init(Paddle paddleLeft, Paddle paddleRight)
    {
        leftPaddle = paddleLeft;
        rightPaddle = paddleRight;
    }

    void IncreaseScore(Paddle paddle)
    {
        paddle.IncreaseScore();
        if (paddle.GetScore() == GameManager.maxScore)
        {
            EndGame(paddle);
        }
        ResetBall(paddle.isRight ? 1 : -1);
    }

    void ResetBall(int xDirection)
    {
        // transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        transform.position = originalPos;
        direction = new Vector2(xDirection, Random.Range(-1f, 1f)).normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            direction.x = -direction.x*(1 + Random.Range(-0.05f, 0.05f));
        }

    }
}
