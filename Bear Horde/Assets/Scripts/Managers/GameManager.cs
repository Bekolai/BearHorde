using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Sequences;
    [SerializeField] GameObject[] FinishSequences;
    Vector3 levelLength = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload same level because it is randomised
    }
    void CreateLevel()
    {
        levelLength.z += 20f;
        for(int i = 0; i < 4; i++) //max 4 sequence on a level
        {
            GameObject sequence = Instantiate(Sequences[Random.Range(0, Sequences.Length)], levelLength, Quaternion.identity); //randomise sequences
            levelLength.z += sequence.GetComponent<SequenceLength>().getLength();
            levelLength.z += 10f; //add distance between sequences
        }
        levelLength.z += 10f;
        GameObject finish = Instantiate(FinishSequences[Random.Range(0, FinishSequences.Length)], levelLength, Quaternion.identity); // instantiate finish object
    }
}
