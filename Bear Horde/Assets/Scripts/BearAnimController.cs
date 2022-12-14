using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimController : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
       animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartRunning()
    {
        animator.SetBool("Idle", false); 
        animator.SetTrigger("Run");
    }
    public void Buff()
    {
        animator.ResetTrigger("Attack3");
        animator.SetTrigger("Buff");
    }
    public void Death()
    {
        animator.ResetTrigger("Run");
        animator.SetTrigger("Death");
    }
    public void Attack()
    {
        animator.ResetTrigger("Run");
        animator.SetTrigger("Attack3");
    }
    public void getHit()
    {
        animator.SetTrigger("GetHit");
    }
    public void Sleep()
    {
        animator.Play("Sleep");
    }
}
