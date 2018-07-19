using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] bool autoPlay = false;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float leftScreenLimit = 1f;
    [SerializeField] float rightScreenLimit = 15f;

    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            FollowMouse();
        } else
        {
            AutoPlay();
        }
        
	}

    private void AutoPlay()
    {
        Vector3 ballPos = ball.transform.position;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(ballPos.x, leftScreenLimit, rightScreenLimit);
        transform.position = paddlePos;
    }

    void FollowMouse()
    {
        float mousePosX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosX, leftScreenLimit, rightScreenLimit);
        transform.position = paddlePos;
    }
}
