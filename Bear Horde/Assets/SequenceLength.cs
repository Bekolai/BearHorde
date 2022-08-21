using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceLength : MonoBehaviour
{
    [SerializeField] int length;
    // Start is called before the first frame update
    void Start()
    {
        if(length == 0)
        {
            Debug.Log("Length not set: " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getLength()
    {
        return length; //return z 
    }
}
