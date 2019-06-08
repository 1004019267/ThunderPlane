using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveEnemy : MonoBehaviour {
    public GameObject[] Enemys;
    public bool isNull=false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isNull==true)
        {
      var go=   Random.Range(0, Enemys.Length);
            Instantiate(Enemys[go]);
            isNull = false;
        }      
	}
}
