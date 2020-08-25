using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public BasePlayerAnimator AniCon;
    public float yTarget;

    private void Start()
    {
        AniCon.Start();
    }

    
    void Update()
    {
        AniCon.Play(1);

        if(AniCon.AnimationActions[AniCon.CurrentAnimation].neutral)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                if (AniCon.CurrentAnimation != 1)    //if the up arrow is pressed the y value should go to 1
                    AniCon.Change(1, .3f);
                yTarget = Mathf.MoveTowards(yTarget, 1, .05f);
            }
        }
        else
        {
            if (AniCon.CurrentAnimation != 0)        //when the up arrow is released it should go to zero
                AniCon.Change(0, .4f);
            yTarget = Mathf.MoveTowards(yTarget, 0, .05f);
        }
        AniCon.animator.SetFloat("y", yTarget); // this is to control the y value in my animation controller to move forward
    }
}
