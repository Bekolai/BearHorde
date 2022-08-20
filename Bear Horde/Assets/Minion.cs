using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    BearAnimController bearAnimController;
    void Awake()
    {
        bearAnimController = GetComponent<BearAnimController>();
    }
    // Start is called before the first frame update
    void Start()
    {
       // bearAnimController.StartRunning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MinionDie()
    {
        transform.parent = null;
        bearAnimController.Death();
        Destroy(gameObject, 2f);
    }
    public void MinionPicked()
    {
        bearAnimController.StartRunning();
        transform.rotation=Quaternion.Euler(0,0,0);
    }
}
