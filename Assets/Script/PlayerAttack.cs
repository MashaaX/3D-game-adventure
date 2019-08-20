using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        //Attack Animation
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("attack");
        }
    }
}
