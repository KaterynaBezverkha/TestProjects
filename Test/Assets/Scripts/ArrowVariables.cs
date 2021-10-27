using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVariables : MonoBehaviour
{
    [SerializeField] private Transform[] points; 
    [SerializeField] private ArrowController line;

    private void Start()
    {
        line.SetUpLine(points);
        points[0] = GameController.instance.FindBall().gameObject.transform;
        points[1] = GameObject.Find("Player").gameObject.transform;
    }

    private void Update()
    {
        if (points[0]==null)
        {
            points[0] = GameController.instance.FindBall().gameObject.transform;
        }
    }
}
