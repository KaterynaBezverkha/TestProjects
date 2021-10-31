using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPadController : MonoBehaviour
{
    public float rot;


    public void TurnLeft()
    {
        if (Input.GetMouseButton(0))
        {
            rot += 1f;
        }
        else
        {
            rot = 0;
        }
    }

    public void TurnRight()
    {
        if (Input.GetMouseButton(0))
        {
            rot -= 1f;
        }
        else
        {
            rot = 0;
        }
    }

    public void Attack()
    {
        print("attack");
    }

    public void Ultimate()
    {
        print("ulta");
    }

}
