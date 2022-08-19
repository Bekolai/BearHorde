using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public enum set_changeType
    {
        Increase,
        Decrease,
        Multiple,
        Divison
    }
    public enum set_bearColor
    {
        Black,
        Red,
        Yellow
    }



    [SerializeField] GameObject minionPrefab;
    [SerializeField] GameObject minionsObj;
    [SerializeField] GameObject player;

    [SerializeField] Material[] materials;
    public List<GameObject> Minions;
    set_bearColor set_BearColor;
    public static MinionController Instance { get; private set; }
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
    void Start()
    {
        Minions.Add(player);
    }


    public void IncreaseMinion(int increaseSize)
    {
        for(int i = 0; i < increaseSize; i++)
        {
            if(Minions.Count>=19)
            {
                break;
            }

            GameObject minion = Instantiate(minionPrefab, minionsObj.transform.position, Quaternion.identity, minionsObj.transform); //create prefab
            Minions.Add(minion); // add minion to list
            setPosition();
        }
    }
    public void DecreaseMinion(int decreaseSize)
    {
       for(int i=0;i<decreaseSize;i++)
        {
            if (Minions.Count > 1)
            {
                GameObject minion = Minions[Minions.Count-1];
                Minions.RemoveAt(Minions.Count-1);
                minion.GetComponent<Minion>().MinionDie();
                setPosition(); //set pos after removing minion

            }
            else
                Debug.Log("GameOver");
        }

    }
    public void MultipleMinion(int increaseSize)
    {
        
        int totalIncrease=Minions.Count*increaseSize;
        totalIncrease -= Minions.Count;
        IncreaseMinion(totalIncrease);
    }
    public void DivisonMinion(int decreaseSize)
    {
        int totalDecrease = Minions.Count / decreaseSize;
        totalDecrease =  Minions.Count-totalDecrease;
        DecreaseMinion(totalDecrease);
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
                    case 2: offset.x = 1.2f; offset.z = 0.25f; break;
                    case 0: offset.x = -1.2f; offset.z = 0.25f; break;
                }
                offset.z +=-0.75f+(row*-1.75f);
                Minions[i].transform.localPosition = offset;

            }
        
        }
    
    }
    public void removeMinion(GameObject diedMinion)
    {
        if (Minions.Count > 1)
        {

            Minions.Remove(diedMinion);
            diedMinion.GetComponent<Minion>().MinionDie();
            setPosition();//set pos after removing minion
        }
        else
            Debug.Log("GameOver");
       
    }
    public void changeColor(set_bearColor color)
    {
       if(color==set_BearColor)
        {
            return;
        }
       switch(color)
        {
            case set_bearColor.Black:
                set_BearColor = set_bearColor.Black;
                foreach (GameObject minion in Minions)
                {
                    minion.GetComponent<SkinnedMeshRenderer>().material = materials[0];
                }
                break;
            case set_bearColor.Red:
                set_BearColor = set_bearColor.Red;
                foreach (GameObject minion in Minions)
                {
                    minion.GetComponent<SkinnedMeshRenderer>().material = materials[1];
                }
                break;
            case set_bearColor.Yellow:
                set_BearColor = set_bearColor.Yellow;
                foreach (GameObject minion in Minions)
                {
                    minion.GetComponent<SkinnedMeshRenderer>().material = materials[2];
                }
                break;
        }


   

    }

}
