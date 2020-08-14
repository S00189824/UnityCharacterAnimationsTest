using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFacter = 0.5f;
    public bool LookAtPLayer = false;
    public bool RotateAroundPlayer = true;
    public float RotationSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            cameraOffset = camTurnAngle * cameraOffset;
        }


        Vector3 newpos = PlayerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newpos, SmoothFacter);


        if (LookAtPLayer || RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
    }

    
}
    
