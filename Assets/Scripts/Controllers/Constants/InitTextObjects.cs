using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitTextObjects : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Text petalText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text livesText;

    // Start is called before the first frame update
    void Awake() {
        WorldObjects.PetalText = petalText;
        WorldObjects.ScoreText = scoreText;
        WorldObjects.TimeText = timeText;
        WorldObjects.LivesText = livesText;
    }
}
