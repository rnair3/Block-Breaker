﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Cached components
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroy();
        gameStatus.CalculateScore();
        Destroy(gameObject);
    }
}
