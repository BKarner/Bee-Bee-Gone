using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Add a menu controller script to this which cycles through text buttons.
 */
public class MenuController : MonoBehaviour {
    #region CONSTANTS
    const string UP_KEY = "up";
    const string DOWN_KEY = "down";
    const string SELECT_KEY = "return";
    #endregion

    #region EDITOR_VARS

    [Header("References")]
    [SerializeField] private MenuEntry[] segues;
    [SerializeField] private AudioClip selectSound;
    [SerializeField] private AudioClip changeSound;

    #endregion

    #region PRIVATE_VARS
    private int selectionIndex = 0;
    private MenuEntry current;
    private AudioSource audio;
    #endregion

    #region METHODS

    // Start is called before the first frame update
    void Start() {
        // Create an audio source
        this.audio = gameObject.AddComponent<AudioSource>();
        this.audio.playOnAwake = false;

        this.current = this.segues[this.selectionIndex];
        Highlight(this.current);
    }

    // Update is called once per frame
    void Update() {
        // Whether or not we're gonna update our selection.
        bool didUpdateSelection = false;

        if (Input.GetKeyUp(DOWN_KEY)) {
            // Decrement our selection.
            this.selectionIndex++;
            didUpdateSelection = true;

        } else if(Input.GetKeyUp(UP_KEY)) {
            // Increment our selection.
            this.selectionIndex--;
            didUpdateSelection = true;

        } else if (Input.GetKeyUp(SELECT_KEY)) {
            // Actually select our current.
            Select(current);
        }

        // Update our selection and highlight it.
        if (didUpdateSelection) {
            // Play our change entry sound.
            this.audio.PlayOneShot(changeSound);

            // Negative mod doesn't work in unity, disgustang.
            this.selectionIndex = ((this.selectionIndex %= this.segues.Length) < 0) ? this.selectionIndex + this.segues.Length : this.selectionIndex;

            Highlight(this.segues[this.selectionIndex]);
        }
    }

    /**
     * Select the current segue.
     */ 
    private void Select(MenuEntry segue) {
        // Play our one shot for the selection.
        audio.PlayOneShot(selectSound);
        segue.Select();
    }

    /**
     * Highlight the new UI element.
     */
    private void Highlight(MenuEntry segue) {
        // Highlight our new segue.
        this.current.Highlight(false);
        segue.Highlight(true);

        this.current = segue;
    }

    #endregion
}
