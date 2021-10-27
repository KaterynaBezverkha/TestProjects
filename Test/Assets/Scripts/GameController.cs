using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject ballPref;
    public GameObject blocksPref;

    GameObject ball = null;
    GameObject blocks = null;

    public int level = 1;
    public float enemySpeed = 0.002f;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FindBall();
        FindBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null)
        {
            Instantiate<GameObject>(ballPref);
            FindBall();
        }

        if (blocks == null)
        {
            level++;
            enemySpeed += 0.004f;
            UIController.instance.levelText.text = "Level: " + level;

            Instantiate<GameObject>(blocksPref);
            FindBlocks();
        }

    }

    public GameObject FindBall()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        return ball;
    }

    public GameObject FindBlocks()
    {
        blocks = GameObject.FindGameObjectWithTag("Blocks");
        return blocks;
    }
}
