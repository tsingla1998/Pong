using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public ScoreText leftScoreText;
    public ScoreText rightScoreText;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    public static int maxScore = 7;



    // Start is called before the first frame update
    void Start()
    {
        // Screen to World Position
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Ball gameBall = Instantiate (ball) as Ball;

        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;

        paddle1.Init(true, rightScoreText);
        paddle2.Init(false, leftScoreText);

        gameBall.Init(paddle2, paddle1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
