using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHoney : MonoBehaviour
{
    public GameObject glob;
    public GameObject spawnpoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "honeyglob")
        {
            StartCoroutine(SpawnHoney());
        }
    }
    IEnumerator SpawnHoney()
    {
        yield return new WaitForSeconds(5);
        GameObject respawnedHoney = Instantiate(glob, spawnpoint.transform.position, Quaternion.identity);
        respawnedHoney.gameObject.tag = "honeyglob";
    }
}
