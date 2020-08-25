using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateAnimationScript : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("y", Input.GetAxis("Vertical"));
        animator.SetFloat("x", Input.GetAxis("Horizontal"));
    }
}
