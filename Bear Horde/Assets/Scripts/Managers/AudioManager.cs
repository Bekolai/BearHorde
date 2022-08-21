using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] AudioClip increaseSFX, decreaseSFX, failSFX, winSFX, colliderSFX,pushCollect;
    AudioSource audioSource;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        audioSource=GetComponent<AudioSource>();

    }
    public void PlayIncreaseSFX()
    {
       
        audioSource.PlayOneShot(increaseSFX, 0.7F);
    }
    public void PlayDecreaseSFX()
    {

        audioSource.PlayOneShot(decreaseSFX, 0.7F);
    }
    public void PlayFailSFX()
    {

        audioSource.PlayOneShot(failSFX, 0.7F);
    }
    public void PlayWinSFX()
    {

        audioSource.PlayOneShot(winSFX, 0.7F);
    }
    public void PlayColliderSFX()
    {

        audioSource.PlayOneShot(colliderSFX, 0.7F);
    }
    public void PlayPushCollectSFX()
    {

        audioSource.PlayOneShot(pushCollect, 0.7F);
    }
}
