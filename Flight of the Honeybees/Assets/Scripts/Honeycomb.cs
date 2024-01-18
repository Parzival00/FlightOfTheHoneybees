using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Honeycomb : MonoBehaviour
{
    public Material empty;
    public Material nectar;
    public Material pollen;
    public Material defaultMat;

    public GameObject nectarImage;
    public GameObject pollenImage;

    public StoreFoodGameManager SFGM;

    public bool isempty;
    public bool isnectar;
    public bool ispollen;

    public bool neednectar;
    public bool needpollen;

    private Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        ren.enabled = true;
        SFGM = GameObject.Find("StoreFoodGameManager").GetComponent<StoreFoodGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var tempmats = ren.sharedMaterials;
        if (isempty)
        {
            tempmats[1] = empty;
        }
        else if (isnectar)
        {
            tempmats[1] = nectar;
        }
        else if (ispollen)
        {
            tempmats[1] = pollen;
        }
        else
        {
            tempmats[1] = defaultMat;
        }
        ren.sharedMaterials = tempmats;
    }
    private void OnCollisionEnter(Collision other)
    {
        var otherName = other.gameObject.name;
        if (otherName.Contains("Pollen") && needpollen)
        {
            ispollen = true;
            isempty = false;
            pollenImage.SetActive(false);
            needpollen = false;
            SFGM.ChangePoints(1); 
            Destroy(other.gameObject);
            StartCoroutine(ResetComb());
        }
        else if (otherName.Contains("Nectar") && neednectar)
        {
            isnectar = true;
            isempty = false;
            nectarImage.SetActive(false);
            neednectar = false;
            SFGM.ChangePoints(1);
            Destroy(other.gameObject);
            StartCoroutine(ResetComb());
        }
        else if ((otherName.Contains("Pollen") && neednectar) || (otherName.Contains("Nectar") && needpollen))
        {
            SFGM.ChangePoints(-1);
        }
        else
        {
            SFGM.ChangePoints(0);
        }
    }

    IEnumerator ResetComb()
    {
        yield return new WaitForSeconds(60);
        isempty = true;
        ispollen = false;
        isnectar = false;
        neednectar = false;
        needpollen = false;
    }

    public void SetupHoneycomb(String type)
    {
        isempty = true;
        isnectar = false;
        ispollen = false;
        if(type == "Pollen")
        {
            pollenImage.SetActive(true);
            needpollen = true;
        }
        if (type == "Nectar")
        {
            nectarImage.SetActive(true);
            neednectar = true;
        }
    }
}
