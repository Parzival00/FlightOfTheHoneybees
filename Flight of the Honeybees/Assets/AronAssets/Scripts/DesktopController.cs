using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DesktopController : MonoBehaviour
{
    // This script allows the player to move around in Desktop 
    [SerializeField] float MoveSpeed; 
    CharacterController controller; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

    }
    // Update is called once per frame
    void Update()
    {

        // Allow player movement with character controller 
        float x = Input.GetAxis("Horizontal") * MoveSpeed;
        float z = Input.GetAxis("Vertical") * MoveSpeed;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * Time.deltaTime);

        // Rotate Player with Mouse movements 
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * MoveSpeed);
        transform.Rotate(Vector3.left, mouseY * MoveSpeed);

        // Lock Z rotation 
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
