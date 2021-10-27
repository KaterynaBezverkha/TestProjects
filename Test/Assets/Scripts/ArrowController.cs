using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points; //objects between which arrow will appear (ball and cube)

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false; //disable arrow at start
    }

    public void SetUpLine(Transform[] points) //drawing the line with an arrow sprite on it
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update()   //update position of line (arrow)
    {
        if (points[0] != null)
        {
            for (int i = 0; i < points.Length; i++)
            {
                lr.SetPosition(i, points[i].position);
            }
        }
    }
}
