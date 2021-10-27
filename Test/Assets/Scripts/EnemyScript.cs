using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject ball = null;
    float speed;
    private Vector3 enemyDirection;

    void Update()
    {
        speed = GameController.instance.enemySpeed; //getting the speed value for enemy from GameController 

        if (ball == null)
        {
            ball = GameController.instance.FindBall(); //finding a new ball in case the previous one was destroyed
        }
        else                                           //moving the enemy towards the ball but only at z axis 
        {
            enemyDirection = ball.transform.position - transform.position;
            enemyDirection = enemyDirection.normalized;
            enemyDirection = new Vector3(0, 0, Mathf.Clamp(enemyDirection.z, -3.15f, 4.25f));
            transform.Translate(enemyDirection * speed, Space.World);
        }
    }

}
