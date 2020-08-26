using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController playerController;

    public Vector3 velocity;
    Vector3 lastVelocity;

    public float speed;
    public float baseSpeed;
    public float SprintSpeed;

    float jumpHeight;
    public float baseJumpHeight;
    float jumpVelocity;

    float fallSpeed;
    public float baseFallSpeed;
    public float WallJumpAngle;

    public CameraController cameraController;

    void Start()
    {
        speed = 0;

        playerController = GetComponent<CharacterController>();

        
        fallSpeed = baseFallSpeed;
        jumpHeight = baseJumpHeight;


    }

    void Update()
    {

        SetSpeed();

        velocity = Vector3.zero;
        velocity = (-cameraController.transform.right * Input.GetAxis("Horizontal") + -cameraController.transform.forward * Input.GetAxis("Vertical")) * speed;
        
        if (playerController.isGrounded)
            Jump();
        else
            Fall();

        Debug.Log(speed);
        

        Move();
    }

    void Move()
    {
        velocity.y = 0;
        velocity.y = jumpVelocity;

        playerController.Move(velocity * Time.deltaTime);
        lastVelocity = velocity;
    }

    void Jump()
    {
        jumpVelocity = -1;

        if (Input.GetKeyDown(KeyCode.Space))
            jumpVelocity = jumpHeight;
    }

    void Fall()
    {
        jumpVelocity -= fallSpeed * Time.deltaTime;
        velocity = lastVelocity;
    }

    void SetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
            speed = SprintSpeed;
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            speed = baseSpeed;
        else
            speed = 0;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!playerController.isGrounded && hit.normal.y < 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 5);
                jumpVelocity = jumpHeight;
                velocity = (hit.normal + new Vector3(0, WallJumpAngle, 0)) * speed;
            }
        }
    }
}
