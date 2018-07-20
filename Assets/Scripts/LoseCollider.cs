using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour {

    private string gameOverScene = "Lose Screen";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Block.blockCount = 0;
        SceneManager.LoadScene(gameOverScene);
    }
}
