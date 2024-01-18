using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StoreFoodGameManager : MonoBehaviour
{
    public GameObject[] HoneycombList;

    public bool isrunning;

    public int points;

    public Timer timer;

    public TextMeshProUGUI pointsTMP;

    private int HClistLength;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        HClistLength = HoneycombList.Length;
        isrunning = false;
        timer = GetComponent<Timer>();
    }

    private void Update()
    {
        pointsTMP.text = "Points: " + points;
    }

    public void SetRunning(bool toset)
    {
        isrunning = toset;
    }

    IEnumerator game()
    {
        while (isrunning)
        {
            System.Random rand = new System.Random();
            var tempnum = rand.Next(HClistLength);
            var randimage = rand.Next(2);
            var currentComb = HoneycombList[tempnum].GetComponent<Honeycomb>();
            if (currentComb.needpollen == true || currentComb.neednectar == true)
            {
                continue;
            }
            if (randimage == 0)
            {
                currentComb.SetupHoneycomb("Pollen");
            }
            if (randimage == 1)
            {
                currentComb.SetupHoneycomb("Nectar");
            }
            yield return new WaitForSeconds(5);
        }
    }

    public void StartGame()
    {
        StartCoroutine(game());
    }
    public void ChangePoints(int score)
    {
        points += score;
    }
    public void ClearPickups()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("storefoodpickup");
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
