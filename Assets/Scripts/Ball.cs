using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 10f;
    float minxSpeed = 1.5f;
    float minySpeed = 8f;
    float maxxSpeed = 2.5f;
    float maxySpeed = 11f;

    Vector2 paddleToBallDiff;
    bool launched = false;

	// Use this for initialization
	void Start () {
        paddle1 = GameObject.FindObjectOfType<Paddle>();
        paddleToBallDiff = transform.position - paddle1.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!launched)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
            launched = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallDiff;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f));
        if (launched)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
        
    }
}
