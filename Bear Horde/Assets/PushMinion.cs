using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PushMinion : MonoBehaviour
{
    [SerializeField] TMP_Text minionCountText;
    int minionCount;
    public minionColor MinionColor;
    [SerializeField] GameObject[] minionsPrefab;
    [SerializeField] List<GameObject> minions;
    GameObject selectedMinionPref;

    // Start is called before the first frame update
    void createMinions()
    {
        for (int i = 0; i < minionCount; i++)
        {
            int row = i / 2;
            if (i % 2 == 0)
            {
                Vector3 spawnPos = new Vector3(-0.5f, 0, (1.75f * row));
                GameObject minion = Instantiate(selectedMinionPref,transform.position+ spawnPos, Quaternion.identity, transform);
                minions.Add(minion);
            }
            else
            {
                Vector3 spawnPos = new Vector3(0.5f, 0, (1.75f * row));
                GameObject minion = Instantiate(selectedMinionPref, transform.position + spawnPos, Quaternion.identity, transform);
                minions.Add(minion);

            }

        }
    }
    
    void Start()
    {
        minionCount = Random.Range(4, 12);
        minionCountText.text = minionCount.ToString();
        selectedMinionPref = minionsPrefab[0]; createMinions();

    }
    public void setColor(minionColor color)
    {
        MinionColor= color;   
        switch(MinionColor) //select prefab according to randomised color
        {
            case minionColor.Black:
                selectedMinionPref = minionsPrefab[0];break;
            case minionColor.Red:
                selectedMinionPref = minionsPrefab[1]; break;
            case minionColor.Yellow:
                selectedMinionPref = minionsPrefab[2]; break;
        }
    }
   
}
