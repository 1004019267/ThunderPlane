using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePool
{
    protected GameObject prefab;
    protected Queue<GameObject> pools = new Queue<GameObject>();

    public FirePool(GameObject prefab)
    {
        this.prefab = prefab;
    }
    public GameObject Get()
    {
        if (pools.Count == 0)
        {
            var go = GameObject.Instantiate(prefab);
            pools.Enqueue(go);
        }
        var obj = pools.Dequeue();
        obj.SetActive(true);
        return obj;
    }
    public void Recover(GameObject go)
    {
        go.SetActive(false);

        var poolReset = go.GetComponent<IPoolReset>();
        if (poolReset!=null)
        {
            poolReset.Reset();
        }
        //清除go数据
        pools.Enqueue(go);
    }
}
