using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class Boss : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int healthMin=250,healthMax=400;
    [SerializeField] Slider hpSlider;
    [SerializeField] TMP_Text hpText;
    int attackNumber;

    Animator animator;
    MinionController minionController;
    
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
        hpSlider.maxValue = health;
        hpSlider.value = health;
        hpText.text = health.ToString();
        minionController = MinionController.Instance;
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
            hpText.text = health.ToString();
            hpSlider.value = health;
        }
        
    }
    void bossDie()
    {
        died = true;
        hpSlider.gameObject.SetActive(false);
        animator.SetBool("Death", true);
    }
    public bool isDied()
    {
        return died;
    }
    public void startBossAttack()
    {
        if (minionController.Minions.Count > 1)
            {
                attackNumber = Random.Range(1, minionController.Minions.Count - 1);
            }
            else
                attackNumber = 0;
        StartCoroutine(coStartBossAttack());
       
        
    }
    public void bossKillMinion()
    {
        minionController.bossKillMinion(minionController.Minions[attackNumber]);
    }
    IEnumerator coStartBossAttack()
    {


        transform.DOLookAt(minionController.Minions[attackNumber].transform.position,0.5f);
        yield return new WaitForSeconds(0.5f);
        if (minionController.Minions.Count > 0)
        {
            animator.SetTrigger("Attack2");
        }
    }
}
