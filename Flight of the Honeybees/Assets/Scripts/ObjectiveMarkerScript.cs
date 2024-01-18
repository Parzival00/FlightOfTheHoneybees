//Place this script on the canvas GameObject of the flowerbeds
//Can be used with the canvas GameObject to make waypoints in the future

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveMarkerScript : MonoBehaviour
{

    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Forced the UI of the Canvas w/ this script to constantly face the camera
        transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward, playerCamera.transform.rotation * Vector3.up);
    }
}
