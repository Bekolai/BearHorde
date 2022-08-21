using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AImanager : MonoBehaviour
{
    public static AImanager Instance { get; private set; }
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

    }
    public Transform target;
    public float RadiusAroundTarget = 0.5f;
    public List<Bear> Units = new List<Bear>();
    void Start()
    {
        target = GameObject.Find("Boss").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SwarmTarget();
        }
    }
    public void SwarmTarget()
    {
        for (int i = 0; i < Units.Count; i++)
        {
            Units[i].MoveTo(new Vector3(
                target.position.x + RadiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / Units.Count),
                target.position.y,
                target.position.z + RadiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / Units.Count)));
            Units[i].LookAt(target);
        }
    }
    public void StartSwarmTarget()
    {
         StartCoroutine(coSwarmTarget());
       // SwarmTarget();

    }
    IEnumerator coSwarmTarget()
    {
        SwarmTarget();
        yield return new WaitForSeconds(2f);
        SwarmTarget();
        yield return new WaitForSeconds(2f);
        SwarmTarget();
        Boss.Instance.startBossAttack();

    }

}
