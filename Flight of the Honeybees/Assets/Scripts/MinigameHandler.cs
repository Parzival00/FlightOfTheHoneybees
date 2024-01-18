//Place this script on the Minigame Handler GameObject
//This script has all of the information needed for the first minigame. Later minigames can utilize this script by adding more methods

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigameHandler : MonoBehaviour
{
    //Objective Variable
    public int flowers;

    public GameObject[] flowerBeds;
    public GameObject[] arrow;
    public Texture[] objTextures = new Texture[5];

    public GameObject Page1;
    public GameObject Page1Button;
    public GameObject Page2;
    public GameObject Page2Button;
    public GameObject Page3;
    public GameObject Page3Button;
    public GameObject Page4;
    public GameObject Page4Button;
    public GameObject stageCompleteMenu;
    public GameObject pollenCount;
    //public float stageTimer = 0;
    //public GameObject noFlower;       //UI is a single object, so I replace the texture of the image
    //public GameObject oneFlower;      //object instead of turning an image off and on.
    //public GameObject twoFlower;
    //public GameObject threeFlower;
    //public GameObject fourFlower;

    CanvasRenderer tRenderer;
    public RawImage objUI;

    public float timer = 20;
    public int count = 0;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        //Assignment of Canvas Renderer to tRenderer
        tRenderer = objUI.GetComponent<CanvasRenderer>();
        Page1.SetActive(true);
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 0;
                count++;
                timerIsRunning = false;
                //If Page1 is active on the player obj, activate its button
                if (Page1.activeInHierarchy)
                {
                    Page1Button.SetActive(true);
                }
                //If Page2 is active on the player obj, activate its button
                if (Page2.activeInHierarchy)
                {
                    Page2Button.SetActive(true);
                }
                //If Page3 is active on the player obj, activate its button
                if (Page3.activeInHierarchy)
                {
                    Page3Button.SetActive(true);
                }
                //If Page4 is active on the player obj, activate its button
                if (Page4.activeInHierarchy)
                {
                    Page4Button.SetActive(true);
                }
            }
        }
        //After Page1 is inactive, activate Page2
        if (!Page1.activeInHierarchy && count == 1)
        {
            Page2.SetActive(true);
            timer += 20;
            count++;
            timerIsRunning = true;
        }

        //Checks for the current objective count and updates image according to value
        CheckFlowerCount();
        if (flowers >= 4)
        {
            foreach (GameObject i in flowerBeds)
            {
                i.tag = "Collected";
            }
            foreach (GameObject i in arrow)
            {
                i.SetActive(false);
            }
            //After collecting the number of flowers and Page2 is inactive, then activate Page3
            if (!Page2.activeInHierarchy && count == 3)
            {
                Page3.SetActive(true);
                timer += 20;
                count++;
                timerIsRunning = true;
            }
            //After collecting the number of flowers and Page2 is inactive, then activate Page3
            if (!Page3.activeInHierarchy && count == 5)
            {
                Page4.SetActive(true);
                timer += 20;
                count++;
                timerIsRunning = true;
            }
            if (!Page4.activeInHierarchy && count == 7)
            {
                stageCompleteMenu.SetActive(true);
                pollenCount.SetActive(false);
            }
        }
    }
    public void CheckFlowerCount()
    {
        if(GameObject.FindGameObjectsWithTag("Collected").Length == 1)
        {
            flowers = 1;
            tRenderer.SetTexture(objTextures[1]);
            //noFlower.SetActive(false);
            //oneFlower.SetActive(true);
            //twoFlower.SetActive(false);
            //threeFlower.SetActive(false);
            //fourFlower.SetActive(false);
        }
        else if (GameObject.FindGameObjectsWithTag("Collected").Length == 2)
        {
            flowers = 2;
            tRenderer.SetTexture(objTextures[2]);
            //noFlower.SetActive(false);
            //oneFlower.SetActive(false);
            //twoFlower.SetActive(true);
            //threeFlower.SetActive(false);
            //fourFlower.SetActive(false);
        }
        else if (GameObject.FindGameObjectsWithTag("Collected").Length == 3)
        {
            flowers = 3;
            tRenderer.SetTexture(objTextures[3]);
            //noFlower.SetActive(false);
            //oneFlower.SetActive(false);
            //twoFlower.SetActive(false);
            //threeFlower.SetActive(true);
            //fourFlower.SetActive(false);
        }
        else if (GameObject.FindGameObjectsWithTag("Collected").Length >= 4)
        {
            flowers = 4;
            tRenderer.SetTexture(objTextures[4]);
            //noFlower.SetActive(false);
            //oneFlower.SetActive(false);
            //twoFlower.SetActive(false);
            //threeFlower.SetActive(false);
            //fourFlower.SetActive(true);
        }
        else
        {
            tRenderer.SetTexture(objTextures[0]);
        }
    }
}
