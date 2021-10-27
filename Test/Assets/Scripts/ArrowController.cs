using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
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
