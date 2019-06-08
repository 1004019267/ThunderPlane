using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour {
    Move move;
    Rigidbody2D rb;
    bool isCome = true;
    GetThing gt;
    // Use this for initialization
    void Start () {
       gt=FindObjectOfType<GetThing>();
        rb = GetComponent<Rigidbody2D>();
        move = FindObjectOfType<Move>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isCome)
        {
  Vector3 dir = Vector3.Normalize(move.transform.position - transform.position);
        dir.z = 0;
        rb.velocity = -dir*10;
            isCome = false;
        }
      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Player1"))
        {
            other.GetComponent<Move>().SetGod();
            gt.GetAc(1);
            Destroy(this.gameObject);
        }
    }
}
