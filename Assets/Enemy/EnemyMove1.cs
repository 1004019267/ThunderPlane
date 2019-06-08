using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove1 : MonoBehaviour {
    public float speed=1.5f;
	void Update () {
        transform.position += Vector3.down * Time.deltaTime * speed * BackGround.scalespeed;
    }
}
