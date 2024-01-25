using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Test : MonoBehaviour
{
    //Outlets
    Animation animation;
    Animator animator;
    
    //State Tracking
    public bool correctAnswer;
    
    //Methods
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (correctAnswer)
        {
            //animation["Cat_Animation_Test"].wrapMode = WrapMode.Once;
            //animation.Play("Cat_Animation_Test");
            animator.SetBool("Correct", true);
        }
    }
}
