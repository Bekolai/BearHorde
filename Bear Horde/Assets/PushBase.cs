using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBase : MonoBehaviour
{
    [SerializeField] GameObject[] pushingObjects;
    List<int> colorRandom = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            colorRandom.Add(i);
        }
        initiateChildObjects();
    }
    void initiateChildObjects()
    {
        for(int i = 0; i < pushingObjects.Length; i++)
        {
            int randomNumber = colorRandom[Random.Range(0,colorRandom.Count)];
            colorRandom.Remove(randomNumber);
            pushingObjects[i].GetComponent<PushMinion>().setColor(randomNumber);




        }
    }



}

