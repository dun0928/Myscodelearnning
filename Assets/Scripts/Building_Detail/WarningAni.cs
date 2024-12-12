using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningAni : MonoBehaviour
{
    private Animator animator;
    private float WarningDirection = -1;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Fadein()
    {
        if (animator == null) return;
        if (WarningDirection==-1)
        {
            WarningDirection = 1;
            animator.SetFloat("WarningDirection", 1);
        }
    }
    public void Fadeout()
    {
        if (animator == null) return;
        if (WarningDirection == 1)
        {
            WarningDirection = -1;
            animator.SetFloat("WarningDirection", -1);
        }
    }
}
