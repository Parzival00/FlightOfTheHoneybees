using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NurseryGameManager : MonoBehaviour
{
    public GameObject[] HoneycombList;
    public GameObject nurseryEndScreen;

    private int HClistLength;
    private int truecount;

    public bool isrunning;
    private bool noRerun;

    private List<LarvaeComb> coveredcombList = new List<LarvaeComb>();

    // Start is called before the first frame update
    void Start()
    {
        HClistLength = HoneycombList.Length;
        isrunning = false;
        noRerun = false;
        truecount = 0;
    }
    private void Update()
    {
        if (isrunning)
        {
            CheckCovered();
        }
    }

    public void SetRunning(bool toset)
    {
        isrunning = toset;
    }
    IEnumerator Game()
    {
        for (int i = 0; i <= 5; i++)
        {
            System.Random rand = new System.Random();
            var tempnum = rand.Next(HClistLength);
            var currentComb = HoneycombList[tempnum].GetComponent<LarvaeComb>();
            currentComb.SetLarvae();
            coveredcombList.Add(currentComb);
            Debug.Log(currentComb.gameObject.name);
        }
        yield return new WaitForSeconds(1);
    }
    public void StartGame()
    {
            StartCoroutine(Game());  
    }

    private void CheckCovered()
    {
        if (!noRerun)
        {
            foreach(LarvaeComb comb in coveredcombList)
            {
                if(!comb.isCovered)
                {
                    break;
                }
                truecount++;
            }
            if(truecount == coveredcombList.Count)
            {
                nurseryEndScreen.SetActive(true);
                noRerun = true;
            }
            truecount = 0;
        }

    }
}
