using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource source;

    public List<AudioClip> clips;

    private void Start() {
        Notify();
    }

    public void Notify(){
        if(PlayerPrefs.GetInt("!sound")==0){
            source.clip = clips[Random.Range(0, clips.Count)];

            source.enabled = true;

            source.Play();
        } else {
            source.enabled = false;
        }
    }

    private void Enable(){

    }

    private void Disable(){

    }
}
