using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    BearAnimController bearAnimController;
    void Awake()
    {
        bearAnimController = GetComponent<BearAnimController>();

    }
    void Update()
    {
        
    }
    public void MinionDie()
    {
        transform.parent = null;
        bearAnimController.Death();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Bear>().enabled = false;
        Destroy(gameObject, 2f);
    }
    public void MinionPicked()
    {
        bearAnimController.StartRunning();
        transform.rotation=Quaternion.Euler(0,0,0);
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collider"))
        {
            
            MinionController.Instance.removeMinion(gameObject);
        }
    }
}
