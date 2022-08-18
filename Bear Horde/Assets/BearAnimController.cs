using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
       animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartRunning()
    {
        animator.SetTrigger("Run");
    }
    public void Buff()
    {
        animator.SetTrigger("Buff");
    }
    public void Death()
    {
        animator.SetBool("Death",true);
    }
    public void getHit()
    {
        animator.SetTrigger("GetHit");
    }
}
