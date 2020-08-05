using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    public Transform cameraAxis;
    public Transform player;
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //setting the upwards/downwards rotaion to the mouse up and down movement
        xRotation += mouseY;
        //stopping it from rotating in circles over the player
        xRotation = Mathf.Clamp(xRotation, -40, 10);

        //setting left and right rotation to the left and right mouse movement
        yRotation += mouseX;

        //making the camera rotate with the previous variables
        cameraAxis.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
