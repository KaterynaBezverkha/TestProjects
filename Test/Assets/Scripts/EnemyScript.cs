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
        speed = GameController.instance.enemySpeed;

        if (ball == null)
        {
            ball = GameController.instance.FindBall();
        }
        else
        {
            enemyDirection = ball.transform.position - transform.position;
            enemyDirection = enemyDirection.normalized;
            enemyDirection = new Vector3(0, 0, Mathf.Clamp(enemyDirection.z, -3.15f, 4.25f));
            transform.Translate(enemyDirection * speed, Space.World);
        }
    }

}
