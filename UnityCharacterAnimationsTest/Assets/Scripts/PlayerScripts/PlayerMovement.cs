using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    OnGroundState,
    WallJumpState
};

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 Velocity;
    float speed;
    public float baseSpeed;
    public float BaseJumpHeight;
    float JumpHeight;
    public bool OnGround;
    public Transform Ground;
    public float FallSpeed;
    public float GroundDistance;
    public LayerMask GroundMask;
    PlayerState CurrentState;

    void Start()
    {
        
    }

    public virtual void Update()
    {
        OnGround = Physics.CheckSphere(Ground.position, GroundDistance, GroundMask);
        OnGroundMovement();
    }


    void OnGroundMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * -h + transform.forward * v;
        controller.Move(move * speed * Time.deltaTime);

        Velocity.y += FallSpeed * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);
    }
}
