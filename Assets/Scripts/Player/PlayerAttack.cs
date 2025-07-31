using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animator;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Melee();
        }
        
    }

    void Melee()

    {

        Animator.SetTrigger("Melee");
    
    }

}
