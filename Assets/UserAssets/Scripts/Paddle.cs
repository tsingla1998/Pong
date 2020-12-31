using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;
    public bool isRight {get; private set;}
    string input;
    int score;
    ScoreText scoreText;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }

    public void Init(bool isRightPaddle, ScoreText scoreText)
    {
        Vector2 pos = Vector2.zero;
        isRight = isRightPaddle;
        this.scoreText = scoreText;
        scoreText.setText("0");

        if (isRightPaddle)
        {
            // Place paddle on the right of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else
        {
            // Place paddle on the left of the screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }
        transform.position = pos;
        transform.name = input;
    }

    public void IncreaseScore() {
        score += 1;
        scoreText.setText(score.ToString());
    }

    public int GetScore() {
        return score;
    }
}
