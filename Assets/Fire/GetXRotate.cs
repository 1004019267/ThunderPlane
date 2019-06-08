using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetXRotate : MonoBehaviour {
    Move move;
    Rigidbody2D rb;
    bool isCome = true;
    GetThing gt;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        move = FindObjectOfType<Move>();
        gt = FindObjectOfType<GetThing>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isCome)
        {
            Vector3 dir = Vector3.Normalize(move.transform.position - transform.position);
            dir.z = 0;
            rb.velocity = -dir * 10;
            isCome = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player1"))
        {
            other.GetComponent<Move>().SetFire4();
            gt.GetAc(4);
            Destroy(this.gameObject);
        }
    }
}
