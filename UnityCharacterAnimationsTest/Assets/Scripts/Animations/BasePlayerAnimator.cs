using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  ///This allows me to use the following variable in the following class below

public class AnimationBehaviour
{
    public string name;
    public int NextAnimation = -1;
    public int end = 60;
    public float transitionSpeed = 0;
    public bool neutral = true;
}

public class BasePlayerAnimator : MonoBehaviour
{
    public List<AnimationBehaviour> AnimationActions = new List<AnimationBehaviour>() { new AnimationBehaviour()};
    public Animator animator;
    public int CurrentAnimation;
    public static float aFrame = 1 / 60f; //How much time passes in a frame, if we assume a frame is 1/60th of a second
    public static float bFrame = 24 / 60f; //Frame rate adjusted from Blender
    public float Frame;

    public void Start()
    {
        Change(0, 0);
        animator.enabled = false;
        Play(1);
    }

    
    void Update()
    {
        print(AnimationActions[CurrentAnimation].name);
    }

    public void Change(int NextAnimation = 0,float transitionSpeed = 0)
    {
        CurrentAnimation = NextAnimation;   //making current animation equal to next Animation
        Frame = 0;                          //resetting frame to zero
        if (transitionSpeed <= 0)
            animator.PlayInFixedTime(AnimationActions[CurrentAnimation].name); // the next animation will be played based on the string name and Plays a state.
        else animator.CrossFadeInFixedTime(AnimationActions[CurrentAnimation].name, transitionSpeed); //Creates a crossfade from the current state to any other state using times in seconds
    }

    public bool Play(float rate)
    {
        animator.Update(rate * aFrame * Time.deltaTime);
        Frame += rate * bFrame * Time.deltaTime;

        bool IsOver = false;

        if (AnimationActions[CurrentAnimation].NextAnimation < 0)
            IsOver = false;

        else if(Frame >= AnimationActions[CurrentAnimation].end)
        {
            int index = CurrentAnimation;
            CurrentAnimation = AnimationActions[CurrentAnimation].NextAnimation;
            Change(AnimationActions[index].NextAnimation, AnimationActions[index].transitionSpeed);
            Frame = 0;
            IsOver = true;
        }
        return IsOver;
    }
}
