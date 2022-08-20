using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class Bear : MonoBehaviour
{

    [SerializeField] int damage=1;
    [SerializeField] NavMeshAgent agent;
    bool reached;
    // Start is called before the first frame update
    void Start()
    {
        AImanager.Instance.Units.Add(this);

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled && !reached)
        {
            if (agent.remainingDistance < 0.1)
            {
               reached = true;
                LookAt(AImanager.Instance.target);
               GetComponent<BearAnimController>().Attack();
            }
        }
       
    }
    public void MoveTo(Vector3 Position)
    {
        if(!agent.enabled)
        {
            agent.enabled = true;
        }
        agent.SetDestination(Position);
    }
    private void OnDestroy()
    {
        AImanager.Instance.Units.Remove(this);
    }
    public void LookAt(Transform target)

    {
        transform.LookAt(target);
    }
    public void DealDamage()
    {
        if(Boss.Instance.isDied())
        {
            GetComponent<BearAnimController>().Buff();
        
        }
        else
        {
            Boss.Instance.bossGetHit(damage);
        }
        
    }

}
