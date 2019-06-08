using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomButter : MonoBehaviour {
    public GameObject boom;
    public GameObject Range;
	// Use this for initialization
	void Start () {
        StartCoroutine(Boom1());
	}
	IEnumerator Boom1()
    {
        yield return new WaitForSeconds(2f);
        var go = Instantiate(boom, transform.position, transform.rotation);
        var go1 = Instantiate(Range,new Vector3(3,9.63f,-0.8f),transform.rotation);     
        Destroy(this.gameObject);
    }
}
