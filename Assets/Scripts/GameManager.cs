// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public CarMovement rbcar;
    public Text levelCounterText;
    public int levelCounter = 1;
    public void CompleteLevel()
    {
        levelCounter++;
        rbcar.enabled = false;
        completeLevelUI.SetActive( true );
        // Invoke( "Restart", restartDelay );
        Invoke( "GameComplete", restartDelay );
    }
    void GameComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EndGame()
    {
        if( gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log( " GAME OVER" );
            gameOverUI.SetActive( true );
            // Invoke( "Restart", restartDelay );
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        rbcar.FForce += 200f;
        levelCounterText.text = levelCounter.ToString();
    }
}