using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float baseSpeed;
    Vector3 MoveVector;
    Vector3 PreviousJump;
    public bool Onground;
    public Transform Ground;
    public float grounDistance;
    public float fallSpeed;
    public float JumpForce;
    float verticalVelocity;
    float Gravity = 25;

    public LayerMask groundMask;

    

    void Start()
    {
        speed = baseSpeed;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Onground = Physics.CheckSphere(Ground.position, grounDistance,groundMask);
        Move();

        Jump();

        if(controller.isGrounded)
        {
            verticalVelocity = -1;

            if(Input.GetKeyDown(KeyCode.A))
            {
                verticalVelocity = JumpForce;
            }
        }
        else
        {
            verticalVelocity -= Gravity * Time.deltaTime;
            MoveVector = PreviousJump;
        }

        MoveVector.y = 0;
        MoveVector.Normalize();
        MoveVector *= speed;
        MoveVector.y = verticalVelocity;
    }

    

    public virtual void Jump()
    {
        if(Input.GetButtonDown("Jump") && Onground)
        {
            MoveVector.y = Mathf.Sqrt(JumpForce * -2f * fallSpeed);
        }

        
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Onground && MoveVector.y < 0)
        {
            MoveVector.y = -2f;
        }

        //horizontal movement
        Vector3 move = transform.right * -h + transform.forward * v;
        controller.Move(move * speed * Time.deltaTime);

        //vertical velocity
        MoveVector.y += fallSpeed * Time.deltaTime;
        controller.Move(MoveVector * Time.deltaTime);

        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(!controller.isGrounded && hit.normal.y < 0.1f)
        {
            
            if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.30f);
                verticalVelocity = JumpForce;
                //Jump();
                MoveVector = hit.normal * speed;
            }
            
        }

        
    }
}
