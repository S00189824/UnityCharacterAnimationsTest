using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    CameraController CameraController;
    CameraFollow CameraFollow;
    GameObject Trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        CameraController = GetComponent<CameraController>();
        CameraFollow = GetComponent<CameraFollow>();

        CameraController.enabled = true;
        CameraFollow.enabled = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            CameraFollow.enabled = true;
            CameraController.enabled = false;
        }
        Debug.Log(CameraFollow);
        
    }
}
