using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timeLeft;

    public StoreFoodGameManager SFGM;
    public GameObject gameEndScreen;

    public TextMeshProUGUI timerTMP;
    public TextMeshProUGUI pointsTMP;

    private bool timerRunning;
    private bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        SFGM = GameObject.Find("StoreFoodGameManager").GetComponent<StoreFoodGameManager>();
        timerRunning = false;
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0 && timerRunning)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            if(!gameEnded && timerRunning)
            {
                SFGM.SetRunning(false);
                timerRunning = false;
                GameEnd();
                gameEnded = true;
            }
            
        }
        timerTMP.text = "Time: " + Math.Round(timeLeft, 0) + "s";
    }

    void GameEnd()
    {
        gameEndScreen.SetActive(true);
        pointsTMP.text = "Points: " + SFGM.points;
    }
    public void StartTimer()
    {
        timerRunning = true;
        SFGM.isrunning = true;
        SFGM.StartGame();
    }
}
