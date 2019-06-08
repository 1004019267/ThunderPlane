using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemy : MonoBehaviour {
    public static GetEnemy Instance;
   public List<Enemy> enemys = new List<Enemy>();
    GiveEnemy giv;
    
	// Use this for initialization
	void Start () {
        Instance = this;
        giv = FindObjectOfType<GiveEnemy>();      
    var en=  this.GetComponentsInChildren<Enemy>();
        for (int i = 0; i < en.Length; i++)
        {
            enemys.Add(en[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {       
        if (enemys.Count<1)
        {
            giv.isNull = true;
            Destroy(this.gameObject);
        }

	}
}
