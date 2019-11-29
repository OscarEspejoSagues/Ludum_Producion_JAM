using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string Game = "GameScene";
    private string Tutorial = "TutorialScene";
    
    public void PlayGame()
    {
        //LOAD LEVEL
        SceneManager.LoadScene(Game);
    }

    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("QUIT");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(Tutorial);
        //Debug.Log("TUTORIAL");
    }
}
