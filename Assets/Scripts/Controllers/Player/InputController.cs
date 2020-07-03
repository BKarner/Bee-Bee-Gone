using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The controller for input on the local player.
 */
public class InputController : MonoBehaviour {
    const string UP_KEY = "up";
    const string DOWN_KEY = "down";
    const string LEFT_KEY = "left";
    const string RIGHT_KEY = "right";

    #region EDITOR_VARS
    [Header("Settings")]
    [SerializeField] private bool isActive = false;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float fallSpeed = -3.0f;
    [SerializeField] private float moveAngle = -10.0f;

    [SerializeField] private float bumpStunTime = 0.35f;
    [SerializeField] private float deathStunTime = 2.0f;

    [SerializeField] private Sprite aliveSprite;
    [SerializeField] private Sprite deadSprite;

    [Header("References")]
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private PlayerAudioController audio;
    [SerializeField] private CircleCollider2D collider;
    [SerializeField] private SpriteRenderer renderer;
    #endregion

    #region PRIVATE_VARS
    private Vector2 movement = new Vector2(0.0f, 0.0f);
    #endregion

    // Update is called once per frame
    void Update() {
        if (!this.isActive) { return; }

        this.movement.y = (Input.GetKey(UP_KEY) ? this.speed : this.fallSpeed);
        this.movement.x = 0;

        if (Input.GetKey(LEFT_KEY)) { this.movement.x += -this.speed; }
        if (Input.GetKey(RIGHT_KEY)) { this.movement.x += this.speed; }

        transform.eulerAngles = new Vector3(0.0f, 0.0f, ((this.movement.x / this.speed) * this.moveAngle));
    }

    // Fixed Update is called after the regular update.
    private void FixedUpdate() {
        rigidbody2D.velocity = movement;
        audio.UpdateMoving(movement.x != 0 || movement.y > 0);
    }

    // Called when our collision hits another.
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Bump") {
            StartCoroutine(Bump());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Petal") {
            this.audio.Score();
        } else if (collision.gameObject.tag == "Hazard") {
            StartCoroutine(Die());
        }
    }

    /**
     * Kill the player.
     */
    IEnumerator Die() {
        this.audio.Death();
        this.isActive = false;
        collider.enabled = false;

        WorldObjects.GameSession.AddLives(-1);

        renderer.sprite = deadSprite;

        GameObject platform = GetClosestPlatform();
        Vector2 toPos = new Vector2(platform.transform.position.x, platform.transform.position.y + 0.8f);

        this.movement.y = ((toPos.y - transform.position.y) / deathStunTime);
        this.movement.x = ((toPos.x - transform.position.x) / deathStunTime);

        yield return new WaitForSeconds(deathStunTime);

        renderer.sprite = aliveSprite;

        this.isActive = true;
        collider.enabled = true;
    }

    /**
     * Bump our bee, stunning it for a few seconds.
     */
    IEnumerator Bump() {
        this.audio.Bump();
        this.isActive = false;

        // Inverse our x movement for the bump
        this.movement.y = fallSpeed;
        this.movement.x /= -1;

        yield return new WaitForSeconds(bumpStunTime);

        this.isActive = true;
    }

    /**
     * Get the position of the closest platform.
     */
    private GameObject GetClosestPlatform() {
        float closestDist = Mathf.Infinity;

        GameObject closest = null;
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Platform");

        for (int i = 0; i < taggedObjects.Length; i++) {
            float newDist = Vector3.Distance(transform.position, taggedObjects[i].transform.position);
            if (newDist <= closestDist) {
                closestDist = newDist;
                closest = taggedObjects[i];
            }
        }

        return closest;
    }
}
