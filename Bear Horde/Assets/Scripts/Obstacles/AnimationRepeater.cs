using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRepeater : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        callRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callAnimation()
    {
        anim.Play();
    }
    void callRandom()
    {
        float RandomTime = Random.Range(1.5f, 3f);
        Invoke("callAnimation", RandomTime);
    }
}
