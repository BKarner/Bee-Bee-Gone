using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The audio controller to attach to our player.
 */
public class PlayerAudioController : MonoBehaviour {
    #region EDITOR_VARS
    [Header("References")]
    [SerializeField] private AudioClip moveSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip bumpSound;
    #endregion

    #region PRIVATE_VARS
    private AudioSource audio;
    #endregion

    // Start is called before the first frame update
    void Start() {
        // Create an audio source
        this.audio = gameObject.AddComponent<AudioSource>();
        this.audio.playOnAwake = false;

        this.audio.clip = moveSound;
        this.audio.loop = true;
    }

    /**
     * Update whether or not the player is moving and therefore should play sounds.
     */
    public void UpdateMoving(bool isMoving) {
        if (isMoving) {
            if (this.audio.isPlaying) { return; }
            this.audio.Play();
            this.audio.loop = true;
        } else {
            this.audio.loop = false;
        }
    }

    /**
     * Play our bump sound.
     */
    public void Bump() {
        this.audio.PlayOneShot(bumpSound);
    }

    /**
     * Play our score sound.
     */
    public void Score() {
        this.audio.PlayOneShot(scoreSound, 0.1f);
    }

    /**
     * Play our death sound.
     */
    public void Death() {
        this.audio.PlayOneShot(deathSound, 0.1f);
    }
}
