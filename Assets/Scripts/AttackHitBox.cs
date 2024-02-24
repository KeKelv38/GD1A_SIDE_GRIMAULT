using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private bool isAttacking;
    public Animator animator;
    private float timer = 0f;
    private float timeToAttack = 0.25f;

    public static AttackHitBox instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AttackHitBox dans la scène");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        isAttacking = false;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
            animator.Play("Attack");
        }

        if (isAttacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                isAttacking = false;
            }
        }
    }
}
