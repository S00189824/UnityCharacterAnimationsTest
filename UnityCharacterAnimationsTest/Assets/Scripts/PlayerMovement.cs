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


    void Start()
    {
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Onground = Physics.CheckSphere(Ground.position, grounDistance);
        Move();
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
