using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PushMinion : MonoBehaviour
{
    
    int minionCount;
    [SerializeField] int randomMin=5,randomMax=12;
    [SerializeField] List<GameObject> minions;
    public set_bearColor MinionColor;
    [SerializeField] GameObject[] minionsPrefab;


    [SerializeField] TMP_Text minionCountText;
    GameObject selectedMinionPref;

    // Start is called before the first frame update
    void createMinions()
    {   
        minionCount = Random.Range(randomMin, randomMax);
        minionCountText.text = minionCount.ToString();
        for (int i = 0; i < minionCount; i++)
        {
            int row = i / 2;
            if (i % 2 == 0)
            {
                Vector3 spawnPos = new Vector3(-0.5f, 0, (1.75f * row));
                GameObject minion = Instantiate(selectedMinionPref,transform.position+ spawnPos, Quaternion.Euler(0f, 180f, 0), transform);
                minions.Add(minion);
                minion.GetComponent<Animator>().SetBool("Idle", true);
            }
            else
            {
                Vector3 spawnPos = new Vector3(0.5f, 0, (1.75f * row));
                GameObject minion = Instantiate(selectedMinionPref, transform.position + spawnPos, Quaternion.Euler(0f,180f,0), transform);
                minions.Add(minion);
                minion.GetComponent<Animator>().SetBool("Idle", true);

            }
            
        }
    }
    
    void Start()
    {
        

    }
    public void setColor(int colorIndex)
    {
        
        switch(colorIndex) //select prefab according to randomised color
        {
            case 0:
                MinionColor= set_bearColor.Black;   
                selectedMinionPref = minionsPrefab[0];break;
            case 1:
                MinionColor = set_bearColor.Red;
                selectedMinionPref = minionsPrefab[1]; break;
            case 2:
                MinionColor = set_bearColor.Yellow;
                selectedMinionPref = minionsPrefab[2]; break;
        }
        createMinions();
    }
    public void sameColorPush()
    {
        for (int i=0;i<minions.Count; i++)
        {
            if (!MinionController.Instance.AddIndividualMinion(minions[i]))
        {
                return;
        }
            else
            {
                minions[i].GetComponent<Minion>().MinionPicked();
                minions[i].GetComponent<BearNavMesh>().enabled = true;
            }
        }
      
    }
    public int MinionCount()
    {
        return minionCount;
    }
   public void differentColorPush()
    {
        transform.DOMoveZ(transform.position.z-(2.5f*(minionCount/2)), 1f);
        foreach (GameObject minion in minions)
        {
            minion.GetComponent<BearAnimController>().StartRunning();

        }

        StartCoroutine(RemoveMinions(MinionController.Instance.Minions.Count));

    }
    IEnumerator RemoveMinions(int count)
    {
        yield return new WaitForSeconds(0.5f);
        MinionController.Instance.DecreaseMinion(minionCount);
        foreach(GameObject minion in minions)
        {
            minion.GetComponent<Minion>().MinionDie();
            
        }
    }
}
