using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject BlockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;

    // state variables
    [SerializeField] int currentHits; // only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        currentHits++;
        int maxHits = hitSprites.Length + 1;
        if (currentHits >= maxHits)
        {
            DestoryBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = currentHits - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array: " + gameObject.name);
        }
    }

    private void DestoryBlock()
    {
        // Play audioclip
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        //Trigger Sparkles
        TriggerSparklesVFX();

        //Add to Score
        AddScore();

        // Destory the block game object
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void AddScore()
    {
        FindObjectOfType<GameSession>().AddtoScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(BlockSparklesVFX,transform.position,transform.rotation);

        Destroy(sparkles, 1f);
    }
}
