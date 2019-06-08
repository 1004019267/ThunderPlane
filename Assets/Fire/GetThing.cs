using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetThing : MonoBehaviour {
    public GameObject[] things;
    int num;
    Move move;
    public AudioClip[] ac;
    AudioSource au;
    // Use this for initialization
    void Start () {
        au = GetComponent<AudioSource>();
        move = FindObjectOfType<Move>();
	}
    public void GetAc(int num)
    {
        au.clip = ac[num];
        au.Play();    
    }
    // Update is called once per frame
    void Update () {
        
	}
    public void GetThings(Vector3 position,int r)
    {
        if (r<things.Length)
        {
            var go = Instantiate(things[r], position, things[r].transform.rotation);
        }
    }
}
