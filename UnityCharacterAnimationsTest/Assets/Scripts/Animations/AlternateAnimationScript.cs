using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateAnimationScript : MonoBehaviour
{
    public Animator animator;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    


    
    void Update()
    {
        animator.SetFloat("Speed", player.speed);  
    }
}
