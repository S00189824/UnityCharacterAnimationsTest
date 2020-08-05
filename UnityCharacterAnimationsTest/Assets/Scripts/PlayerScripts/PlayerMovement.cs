using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float baseSpeed;
    Vector3 velocity;
    public bool Onground;
    public Transform Ground;
    public float grounDistance;
    public float fallSpeed;
    public float jumpHeight;
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
    }

    

    public virtual void Jump()
    {
        if(Input.GetButtonDown("Jump") && Onground)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * fallSpeed);
        }

        Debug.Log(jumpHeight);
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Onground && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //horizontal movement
        Vector3 move = transform.right * -h + transform.forward * v;
        controller.Move(move * speed * Time.deltaTime);

        //vertical velocity
        velocity.y += fallSpeed * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }

    
}
