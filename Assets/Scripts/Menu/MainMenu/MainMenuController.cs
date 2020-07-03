using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * The custom menu script for our game menu.
 */
public class MainMenuController : MonoBehaviour {
    /**
     * Start our game.
     */
    public void StartGame() {
        SceneManager.LoadScene("level-1");
    }

    /**
     * Load our leaderboards scene.
     */
    public void OpenLeaderboards() {
        // SceneManager.LoadScene();
    }
    
    /**
     * Exit our game.
     */
    public void ExitGame() {
        Application.Quit();
        
    }
}
