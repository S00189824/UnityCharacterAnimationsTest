using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController playerController;

    Vector3 velocity;
    Vector3 lastVelocity;

    float speed;
    public float baseSpeed;

    float jumpHeight;
    public float baseJumpHeight;
    float jumpVelocity;

    float fallSpeed;
    public float baseFallSpeed;
    public float WallJumpAngle;

    public CameraController cameraController;

    void Start()
    {
        playerController = GetComponent<CharacterController>();

        speed = baseSpeed;
        fallSpeed = baseFallSpeed;
        jumpHeight = baseJumpHeight;
    }

    void Update()
    {
        velocity = Vector3.zero;
        velocity = (-cameraController.transform.right * Input.GetAxis("Horizontal") + -cameraController.transform.forward * Input.GetAxis("Vertical")) * speed;

        if (playerController.isGrounded)
            Jump();
        else
            Fall();

        Move();
    }

    void Move()
    {
        velocity.y = 0;
        velocity.y = jumpVelocity;

        playerController.Move(velocity * Time.deltaTime);
        lastVelocity = velocity;

        //Vector3 CamForward = cameraController.transform.forward;
        //Vector3 camRight = cameraController.transform.right;

        //Vector3 TargetLocation = velocity.z * cameraController.transform.forward;
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
