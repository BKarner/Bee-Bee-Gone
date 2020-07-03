using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Retained settings for the entire GameSession
 */
public class GameSession : MonoBehaviour {
    [Header("Settings")]
    public float lives = 2;
    public float score = 0;

    // When the object is awakened.
    private void Awake() {
        WorldObjects.GameSession = this;
    }

    // Start is called before the first frame update
    void Start() {
        WorldObjects.ScoreText.text = score.ToString();
        WorldObjects.LivesText.text = lives.ToString();   
    }

    /**
     * Add score to our game session.
     */
    public void AddScore(float value) {
        score += value;
        WorldObjects.ScoreText.text = score.ToString();
    }

    /**
    * Add lives to our game session.
    */
    public void AddLives(float value) {
        lives += value;
        WorldObjects.LivesText.text = lives.ToString();
    }
}
