using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class LarvaeComb : MonoBehaviour
{
    public Material LarvaeFilled;
    public Material CombCovered;

    public GameObject BabybeeComb;
    public GameObject HoneyComb;
    public GameObject CoverCanvas;

    public bool isEmpty;
    public bool isLarvae;
    public bool isCovered;
    public bool readyforCover;

    private Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        ren = HoneyComb.GetComponent<Renderer>();
        ren.enabled = true;
        isEmpty = true;
        isLarvae = false;
        readyforCover = false;
        isCovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        var tempmats = ren.sharedMaterials;
        if (isLarvae)
        {
            BabybeeComb.SetActive(true);
            HoneyComb.SetActive(false);
        }
        else if (isCovered)
        {
            BabybeeComb.SetActive(false);
            HoneyComb.SetActive(true);
            tempmats[1] = CombCovered;
        }
        ren.sharedMaterials = tempmats;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "honeyglob" && isLarvae)
        {
            BabybeeComb.GetComponent<Renderer>().material = LarvaeFilled;
            Destroy(other.gameObject);
            StartCoroutine(NeedsCover());
        } else if(other.gameObject.tag == "cover" && readyforCover)
        {
            isCovered = true;
            readyforCover = false;
            isLarvae = false;
            Destroy(other.gameObject);
        }
    }
    public void SetLarvae()
    {
        isEmpty = false;
        isLarvae = true;
        isCovered = false;
        readyforCover = false;
    }
    IEnumerator NeedsCover()
    {
        yield return new WaitForSeconds(5);
        readyforCover = true;
        CoverCanvas.SetActive(true);
    }
}
