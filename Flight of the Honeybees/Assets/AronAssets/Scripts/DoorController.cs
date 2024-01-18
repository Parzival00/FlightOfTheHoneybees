using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isOpened) return;
        if (other.tag == "Player") {
            TweenOpen();
        }
    }

    public void TweenOpen() {
        // Tween to open (right movement) 
        // deactivate on complete
        transform.DOMoveY(transform.position.y - 5f, 0.5f).OnComplete(Deactivate);
    }

    void Deactivate() {
        isOpened = true;
        gameObject.SetActive(false);
    }


}
