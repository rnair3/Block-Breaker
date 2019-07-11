using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config parameters
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;

    [SerializeField] int screenWidthInUnits;

    //cached
    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
       // float x = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;

    }

    private float GetXPos()
    {
        if (gameSession.isAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
