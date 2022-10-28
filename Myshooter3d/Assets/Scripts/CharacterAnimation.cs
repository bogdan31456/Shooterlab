using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    public Animator animator;
    public CharacterMovement characterMovement;
    public CharacterStatus characterStatus;
   

    // Update is called once per frame
   public void AnimationUpdate()
    {

        animator.SetBool("sprint",characterStatus.isAiming);
        animator.SetBool("Aiming", characterStatus.isAiming);
        if (characterStatus.isAiming)
            AnimationNormal();
        else
            AnimationAiming();
    }

   void AnimationNormal()
    {
        animator.SetFloat("vertical", characterMovement.moveAmount, 0.15f, Time.deltaTime);
    }

    void AnimationAiming()
    {

        float v = characterMovement.vertical;
        float h=characterMovement.horizontal;

        animator.SetFloat("vertical", v, 0.15f, Time.deltaTime);

        animator.SetFloat("horizontal", h, 0.15f, Time.deltaTime);


    }
}
