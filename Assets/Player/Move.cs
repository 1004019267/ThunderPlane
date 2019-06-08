using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Move : MonoBehaviour
{
    Animator animator;
    public static int score = 0;
    public static int dieNum = 0;
    public float speed = 1;
    public GameObject[] skill;
    bool isGo = false;
    bool isMoveAnimator = false;
    private static Move _instance;
    public static Move Instance
    {
        get
        {
            return _instance;
        }
    }
    public GameObject effectPrefab;
    // Use this for initialization
    float maxX;
    float maxY;
    float halfBoardX;
    float halfBoardY;

    FlyUI ui;
    void Awake()
    {
        _instance = this;
        animator = this.GetComponent<Animator>();
    }
    void Start()
    {
        ui = FindObjectOfType<FlyUI>();
        FlyUI.scoreAdd += this.AddScore;
        FlyUI.dieAdd += this.AddDie;
        Vector3 rect = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        halfBoardX = this.GetComponent<Renderer>().bounds.size.x / 4;
        halfBoardY = this.GetComponent<Renderer>().bounds.size.y / 4;
        maxX = rect.x - halfBoardX;
        maxY = rect.y - halfBoardY;
    }
    public void AddDie()
    {
        dieNum++;
    }
    public void SetGo()
    {
        isGo = true;
        skill[1].SetActive(true);
        skill[4].SetActive(true);
        StartCoroutine(Minute3s());
    }
    public void SetFire4()
    {
        skill[5].SetActive(true);
    }
    public void SetFire3()
    {
        skill[3].SetActive(true);
    }
    public void SetFire2()
    {
        skill[1].SetActive(false);
        skill[2].SetActive(true);
    }
    public void SetGod()
    {
        skill[0].SetActive(true);
        StartCoroutine(Minute4s());
    }
    IEnumerator Minute4s()
    {
        gameObject.tag = "Player1";
        yield return new WaitForSeconds(4);
        gameObject.tag = "Player";
        skill[0].SetActive(false);
    }
    // Update is called once per frame
    IEnumerator Minute3s()
    {
        animator.Play("Live3s");
        gameObject.tag = "Player1";
        yield return new WaitForSeconds(3);
        gameObject.tag = "Player";
    }
    void Update()
    {
        if (isGo)
        {
            //如果点击UI的话 不执行位移
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {
                PlayerMove();
            }
        }
    }
    public void PlayerMove()
    {
        var moP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 nMop = new Vector3(Mathf.Clamp(moP.x, -maxX, maxX), Mathf.Clamp(moP.y, -maxY, maxY), 0);
        float distance = Vector3.SqrMagnitude(transform.position - nMop);
        if (distance > 0.1f)
        {
            if (moP.x - transform.position.x > 4)
            {
                animator.Play("Right");
            }
            if (moP.x - transform.position.x < -4)
            {
                animator.Play("Left");
            }
            Vector3 dir = Vector3.Normalize(nMop - transform.position);
            transform.Translate(dir * speed * Time.deltaTime, Space.World);
        }
    }
    void OnDestroy()
    {
        FlyUI.scoreAdd -= this.AddScore;
        FlyUI.dieAdd -= this.AddDie;
    }

    public void AddScore(int score1 = 100)
    {
        score += score1;
        ui.LookScore(score);
        int maxScore = PlayerPrefs.GetInt("maxScore");
        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("maxScore", maxScore);
        }
        ui.LookMaxScore(maxScore);
    }
    public void Lose()
    {
        AddDie();
        var go = Instantiate(effectPrefab, transform.position, transform.rotation);
        ui.ReGo();
        Time.timeScale = 0;
        float lastPositionX = transform.position.x;
        PlayerPrefs.SetFloat("lastPositionX", lastPositionX);
        float lastPositionY = transform.position.y;
        PlayerPrefs.SetFloat("lastPosition", lastPositionY);
        Destroy(go, 0.5f);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Boss") || other.CompareTag("Boss1"))
            {
                var go = Instantiate(effectPrefab, transform.position, transform.rotation);
                Destroy(go, 0.5f);
                Lose();
            }
        }
    }
}
