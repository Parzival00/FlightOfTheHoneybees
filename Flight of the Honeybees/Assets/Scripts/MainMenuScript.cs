//Place this script on any Menu Controller GameObject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    
    public void MainMenuButton()
    {
        //MainMenuButton goes to the main menu
        //It loads the scene with index 0 in the Build Settings. This scene should be the main menu scene
        SceneManager.LoadScene(0);
    }
    //StartButton starts the game
    //It loads the scene with index 1 in the Build Settings. This scene should be the minigame scene
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    //StartButton starts the tutorial
    //It loads the scene with index 3 in the Build Settings. This scene should be the tutorial scene
    public void StartButton2()
    {
        SceneManager.LoadScene(3);
    }

    //AssetsScene takes the player to the Assets Scene, where they can look at the assets in the game
    //It loads the scene with index 2 in the Build Settings. This scene should be the Assets scene
    public void AssetsScene()
    {
        SceneManager.LoadScene(2);
    }

    //QuitButton quits the game
    //If on a build, it should exit the application. If in the editor, the console should say the Debug.Log below
    public void QuitButton()
    {
        Debug.Log("The Game has been Quit.");
        Application.Quit();
    }
}
