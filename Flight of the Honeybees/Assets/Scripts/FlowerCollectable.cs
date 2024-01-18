//Place this script on the flowerbeds (already on the flowerbed prefab)
//Flowerbeds should have isTrigger checked/enabled in its collider
//Flowerbeds should be tagged as "Flower"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollectable : MonoBehaviour
{
    //arrow is the waypoint canvas GameObject in the child of the flowerbeds prefab
    //collectedPollen is the audiosource in the flowerbeds prefab

    public GameObject arrow;
    public AudioSource collectedPollen;

    //when the player collides with the flower, the flower is turned into the tag "Collected" and a collection sound plays
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collectedPollen.Play();
            arrow.SetActive(false);
            this.gameObject.tag = "Collected";
        }
    }
}
