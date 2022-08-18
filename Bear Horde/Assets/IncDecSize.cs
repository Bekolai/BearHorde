using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum set_changeType
{
    Increase,
    Decrease,
    Multiple,
    Divison
}
public class IncDecSize : MonoBehaviour
{
    [SerializeField] set_changeType changeType;
     int number;
    // Start is called before the first frame update
    void Awake()
    {
        if (changeType == set_changeType.Increase)
        {
            number = Random.Range(1, 5);
        }
        if (changeType == set_changeType.Decrease)
        {
            number = Random.Range(1, 5);
        }
        else if (changeType == set_changeType.Multiple)
        {
            number = Random.Range(2, 4);  
        }
        else if (changeType == set_changeType.Divison)
        {
            number = Random.Range(2, 6);
        }
    }
    public  string getChangeType() => changeType.ToString();
    public int getChangeNumber() => number;


}
