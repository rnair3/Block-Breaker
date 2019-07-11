using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Cached components
    Level level;
    GameSession gameStatus;

    [SerializeField] GameObject sparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //state
    [SerializeField] int timesHit;           //only serialized for debug pruposes

    private void Start()
    {
        CountBreakable();

        gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakable()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleBlockHits();
        }

    }

    private void HandleBlockHits()
    {
        timesHit++;
        if (timesHit >= hitSprites.Length + 1)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        if(hitSprites[timesHit-1]!= null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else
        {
            Debug.Log("Block Sprite missing!!! " + gameObject.name);
        }
        
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroy();
        gameStatus.CalculateScore();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject.Instantiate(sparklesVFX, transform.position, transform.rotation);
        //Destroy(sparklesVFX);
    }
}
