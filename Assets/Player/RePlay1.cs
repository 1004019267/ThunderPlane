using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RePlay1 : MonoBehaviour {  
	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        this.GetComponent<Button>().onClick.AddListener(() => {
            Time.timeScale = 1;
            Move.score = 0;
            Move.dieNum = 0;
            Application.LoadLevel(0);
        });
	}
}
