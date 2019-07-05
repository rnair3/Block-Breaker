﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //config parameters
    [Range(0.1f, 10f)]
    [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;

    //state
    [SerializeField] int currentScore = 0;
    

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void CalculateScore()
    {
        currentScore += pointsPerBlock;
    }
}
