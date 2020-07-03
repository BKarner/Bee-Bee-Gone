using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Our level specific settings!
 */
public class LevelController : MonoBehaviour {
    #region EDITOR_VARS
    [Header("Settings")]
        [Tooltip("The time to complete the level, in minutes")]
        [SerializeField] private float timeToComplete = 5f;

        [Tooltip("The next level to go to")]
        [SerializeField] private string nextLevel;

        [SerializeField] public float cameraMinY = 0.0f;
        [SerializeField] public float cameraMaxY = 0.0f;
    #endregion

    #region PRIVATE_VARS
    private int petalsRemaining = 0;
    #endregion

    #region METHODS
    // Start is called before the first frame update
    void Start() {
        WorldObjects.Level = this;

        GameObject[] petals = GameObject.FindGameObjectsWithTag("Petal");
        foreach (GameObject petal in petals) {
            if (petal.activeInHierarchy) {
                this.petalsRemaining++;
            }
        }

        WorldObjects.PetalText.text = this.petalsRemaining.ToString();
    }

    /**
     * Collect a petal from our level.
     */
    public void CollectPetal() {
        this.petalsRemaining--;
        WorldObjects.PetalText.text = this.petalsRemaining.ToString();

        if (petalsRemaining == 0) {
            NextLevel();
        }
    }

    /**
     * Transition to our next level.
     */
    public void NextLevel() {
        SceneManager.LoadScene(nextLevel);
    }
    #endregion
}
