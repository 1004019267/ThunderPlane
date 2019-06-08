using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFind : MonoBehaviour
{
    public float speed;
    void Update()
    {
        try
        {
            transform.position = Vector3.Lerp(transform.position, Move.Instance.transform.position, speed * Time.deltaTime);
        }
        catch (System.Exception)
        {      
        }
    }
}
