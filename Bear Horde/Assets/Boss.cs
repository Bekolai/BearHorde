using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int healthMin=250,healthMax=400;
    [SerializeField] Slider hpText;

    Animator animator;
    bool died;
    public static Boss Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        animator=GetComponent<Animator>(); 
    }
  
    void Start()
    {
        health = Random.Range(healthMin, healthMax);
        hpText.maxValue = health;
        hpText.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bossGetHit(int damage)
    {
        if(!died)
        {
        health -= damage;
        if(health <= 0)
        {
            health = 0; bossDie();
        }
        hpText.value = health;
        }
        
    }
    void bossDie()
    {
        died = true;
        hpText.gameObject.SetActive(false);
        animator.SetBool("Death", true);
    }
    public bool isDied()
    {
        return died;
    }
}
