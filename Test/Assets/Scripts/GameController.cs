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

    public int level = 1; //level at start
    public float enemySpeed = 0.002f; //enemy speed at start



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
        FindBall(); //finding the first ball on scene
        FindBlocks(); //finding the first blocks on scene
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null)
        {
            Instantiate<GameObject>(ballPref); //creating a new ball in case the previous one was destroyed
            FindBall();
        }

        if (blocks == null) //creating a new blocks and increasing level/enemy speed
        {
            level++;
            enemySpeed += 0.003f;
            UIController.instance.levelText.text = "Level: " + level; //putting a new level value into the UI

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
