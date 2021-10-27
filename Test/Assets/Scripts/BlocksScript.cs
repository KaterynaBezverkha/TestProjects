using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksScript : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

}
