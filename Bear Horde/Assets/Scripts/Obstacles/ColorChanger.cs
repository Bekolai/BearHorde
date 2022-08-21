using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChanger : MonoBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] Color[] colors;
    public set_bearColor set_BearColor;
    [SerializeField] ParticleSystem particle1, particle2;



    MeshRenderer meshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {       var p1 = particle1.main;
            var p2 = particle2.main;
        meshRenderer = GetComponent<MeshRenderer>();
        int random = Random.Range(0, 3);
        switch(random)
        {
            
            case 0:
                set_BearColor = set_bearColor.Black; meshRenderer.material = materials[0];
                p1.startColor = colors[0]; p2.startColor = colors[0];
                break;
            case 1:
                set_BearColor = set_bearColor.Red; meshRenderer.material = materials[1];
                p1.startColor = colors[1]; p2.startColor = colors[1];
                break;
            case 2:
                set_BearColor = set_bearColor.Yellow; meshRenderer.material = materials[2];
                p1.startColor = colors[1]; p2.startColor = colors[1];
                break;
        }
        
    }

}
