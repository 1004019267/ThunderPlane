using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePlay : MonoBehaviour {
    public GameObject player;   
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
          var go=  Instantiate(player, new Vector2(PlayerPrefs.GetFloat("lastPositionX"), PlayerPrefs.GetFloat("lastPositionY")), player.transform.rotation);
            go.GetComponent<Move>().SetGo();
            this.gameObject.SetActive(false);          
        }
	}
}
