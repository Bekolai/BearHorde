using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MinionController;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Material[] materials;
    public set_bearColor set_BearColor;



    MeshRenderer meshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        int random = Random.Range(0, 3);
        switch(random)
        {
            case 0:
                set_BearColor = set_bearColor.Black; meshRenderer.material = materials[0];
                break;
            case 1:
                set_BearColor = set_bearColor.Red; meshRenderer.material = materials[1];
                break;
            case 2:
                set_BearColor = set_bearColor.Yellow; meshRenderer.material = materials[2];
                break;
        }
    }

}
