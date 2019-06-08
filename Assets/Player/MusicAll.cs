using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAll : MonoBehaviour {   
    AudioSource au;
    public  AudioClip[] ac;
	// Use this for initialization
	void Awake () {
        au = GetComponent<AudioSource>();       
	}	
	// Update is called once per frame
    public void Bgm(int num)
    {
        au.clip = ac[num];
        au.Play();
    }  
}
