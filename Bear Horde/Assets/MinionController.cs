using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{   [SerializeField] GameObject minionsObj;
    public GameObject minionPrefab;

    public List<GameObject> Minions;
    
    // Start is called before the first frame update
    void Start()
    {
        Minions.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ChangeSize"))
        {
            IncDecSize incDecSize = other.gameObject.GetComponent<IncDecSize>();
            switch(incDecSize.getChangeType())
            {
                case "Increase": IncreaseMinion(incDecSize.getChangeNumber()); break;
                case "Decrease": DecreaseMinion(incDecSize.getChangeNumber()); break;
                case "Multiple": MultipleMinion(incDecSize.getChangeNumber()); break;
                case "Divison":  DivisonMinion(incDecSize.getChangeNumber());  break;

            }
        }

    }
    void IncreaseMinion(int increaseSize)
    {
        for(int i = 0; i < increaseSize; i++)
        {
            if(Minions.Count>=50)
            {
                break;
            }

            GameObject minion = Instantiate(minionPrefab, minionsObj.transform.position, Quaternion.identity, minionsObj.transform); //create prefab
            Minions.Add(minion); // add minion to list
            setPosition();
        }
    }
    void DecreaseMinion(int decreaseSize)
    {

    }
    void MultipleMinion(int increaseSize)
    {

    }
    void DivisonMinion(int decreaseSize)
    {

    }
    void setPosition()
    {
        int minionsCount=Minions.Count;
        if (minionsCount > 1)
        { 
           for(int i=1; i < minionsCount; i++)
            {
                Vector3 offset=Vector3.zero;
                int verticalPos = i % 3;
                int row=(i-1)/3;
                switch(verticalPos)
                {
                    case 1:offset.x = 0f;break;
                    case 2: offset.x = 1f; break;
                    case 0: offset.x = -1f; break;
                }
                Debug.Log(row);
                offset.z =-1f+(row*-2f);
                Debug.Log(offset);
                Minions[i].transform.localPosition = offset;

            }
        
        }
    
    }
}
