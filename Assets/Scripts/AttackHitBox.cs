using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.Play("Attack");
        }
    }
}
