using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCompleteMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStageButton()
    {
        //For when the next scene is made
        SceneManager.LoadScene("Inside Hive");
    }

    public void ExitStageButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StageSelectButton()
    {
        //For when Stage Select is ever implemented
        //SceneManager.LoadScene("");
    }

}
