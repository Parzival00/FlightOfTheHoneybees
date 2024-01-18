using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsScript : MonoBehaviour
{
    public CanvasRenderer iRenderer;
    public Color white;
    // Start is called before the first frame update
    void Start()
    {
        iRenderer = gameObject.GetComponent<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Busy Bee Unlock Pseudocode
        //if (time <= x:xx){
        //  iRenderer.SetColor(white);
        //}

        //Rose-Tinted Unlock Pseudocode
        //if (Collision.Equals(this.gameObject.CompareTag("Player"), gameObject.CompareTag("Player"))){
        //  iRenderer.SetColor(white);
        //}
    }
}
