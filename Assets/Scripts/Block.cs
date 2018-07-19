using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] public Sprite[] hitSprites;
    [SerializeField] public static int blockCount = 0;
    [SerializeField] public AudioClip crack;

    private SceneLoader levelManager;
    private int maxHits;
    private int timesHit;
    private bool isBreakable;
    

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<SceneLoader>();
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            blockCount++;
            print(blockCount);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            blockCount--;
            print(blockCount);
            Destroy(gameObject);
            levelManager.BlockDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
