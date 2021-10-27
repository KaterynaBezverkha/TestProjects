using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksScript : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.transform.childCount == 0) //destroying main 'block' object if all of it's children were killed
        {
            Destroy(gameObject);
        }
    }
}
