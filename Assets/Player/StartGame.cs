using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public GameObject picture;
    public GameObject ge;
    Move move;
    // Use this for initialization
    void Start()
    {
        move = FindObjectOfType<Move>();
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            Cursor.visible = false;
            picture.SetActive(false);
            ge.SetActive(true);
            move.SetGo();
        });
    }
}
