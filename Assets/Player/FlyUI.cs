using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public delegate void Score(int score);
public delegate void Die();
public class FlyUI : MonoBehaviour {
    Text scoreText;
    Text maxScoreText;
    Text bigBoomText;
    Text lastScoreText;
    Text diedNumText;
    public  GameObject lose;  
    public static Score scoreAdd;
    public static Die dieAdd;
    public GameObject woman;
    public GameObject win;
    public GameObject danger;   
    public bool fireBoom;
    // Use this for initialization
    void Start () {
        transform.Find("Image").GetComponent<Button>().onClick.AddListener(()=> {           
            fireBoom = true;
        });
        diedNumText= transform.Find("Image (2)/Die").GetComponent<Text>();
        lastScoreText = transform.Find("Image (2)/Text").GetComponent<Text>();       
        bigBoomText = GameObject.Find("Image/Text").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        maxScoreText = GameObject.Find("MaxScore").GetComponent<Text>();
	}
    public void Danger()
    {        
        StartCoroutine(Go());
    }  
    IEnumerator Go()
    {
        danger.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        danger.SetActive(false);
    }
    public void winOrNext()
    {
        LastScore(Move.score, PlayerPrefs.GetInt("maxScore"),Move.dieNum);
        Time.timeScale = 0;
        win.SetActive(true);
    }
    IEnumerator On()
    {  woman.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        woman.SetActive(false);
    }
    public void WoMan()
    {
        StartCoroutine(On());
    }
    public void ReGo()
    {
        lose.gameObject.SetActive(true);
    }
    public void BigBoomNum(int num)
    {
        bigBoomText.text =""+ num;
    }
    public void LookMaxScore(int score)
    {
        maxScoreText.text = "MaxScore" + score;
    }
   public void LookScore(int score)
    {
        scoreText.text = "Score" + score;
    }
    public void LastScore(int score,int maxScore,int dieNum)
    {
        lastScoreText.text = "本次得分" + score + "最高分" + maxScore;
        diedNumText.text = "死亡次数:" + dieNum;
    }
}
