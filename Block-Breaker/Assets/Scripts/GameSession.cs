using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config parameters
    [Range(0.1f, 10f)]
    [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    //state
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void CalculateScore()
    {
        currentScore += pointsPerBlock;
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
