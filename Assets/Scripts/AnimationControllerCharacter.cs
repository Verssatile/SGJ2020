using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerCharacter : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("MC_dance");
    }

    public void SetAnimationToPlay(string animationName, bool condition)
    {
        anim.SetBool(animationName, condition);
    }
}
