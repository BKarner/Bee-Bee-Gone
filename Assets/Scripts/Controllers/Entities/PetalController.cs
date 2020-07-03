using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalController : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] private float score = 20.0f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {

            WorldObjects.GameSession.AddScore(this.score);
            WorldObjects.Level.CollectPetal();

            GameObject.Destroy(gameObject);
        }
    }
}
