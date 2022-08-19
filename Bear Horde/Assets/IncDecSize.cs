using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MinionController;
using TMPro;
public class IncDecSize : MonoBehaviour
{
    [SerializeField] set_changeType changeType;
    [SerializeField] int number;
    [SerializeField] TMP_Text text;
    [SerializeField] Material[] materials;
    // Start is called before the first frame update
    void Awake()
    {
        if (changeType == set_changeType.Increase)
        {
            number = Random.Range(1, 5);
            text.text = ($"+{number}");
        }
        else if (changeType == set_changeType.Decrease)
        {
            number = Random.Range(1, 5);
            text.text = ($"-{number}");
        }
        else if (changeType == set_changeType.Multiple)
        {
            number = Random.Range(2, 4);
            text.text = ($"×{number}");
        }
        else if (changeType == set_changeType.Divison)
        {
            number = Random.Range(2, 6);
            text.text = ($"÷{number}");
        }
        GetComponent<MeshRenderer>().material=materials[Random.Range(0,materials.Length-1)];
    }
    public  string getChangeType() => changeType.ToString();
    public int getChangeNumber() => number;


}
