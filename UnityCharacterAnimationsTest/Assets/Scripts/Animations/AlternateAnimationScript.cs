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

    // Update is called once per frame
    void Update()
    {
        if(player)

        animator.SetFloat("Speed", player.speed);
        
    }
}
