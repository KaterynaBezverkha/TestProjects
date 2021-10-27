using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetection : MonoBehaviour
{
    GameObject getTarget = null;
    bool isMouseDragging;
    GameObject ball = null;

    Vector3 previousPos;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    private void Start()
    {
        previousPos = transform.position;
        ball = GameController.instance.FindBall();
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

    void Update()
    {
        if (ball == null)
        {
            ball = GameController.instance.FindBall();
        }
        else 
        {
            if (!BallScript.instance.isBallThrown)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hitInfo;
                    getTarget = ReturnClickedObject(out hitInfo);

                    if (hitInfo.collider == null)
                    {
                        getTarget = null;
                    }
                    else if (getTarget.transform.name == "Player")
                    {
                        GameObject.Find("ArrowController").GetComponent<LineRenderer>().enabled = true;
                        isMouseDragging = true;
                        positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                        offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                    }
                }

                if (Input.GetMouseButtonUp(0) && getTarget!=null)
                {
                    if (getTarget.transform.name == "Player")
                    {
                        isMouseDragging = false;
                        transform.position = previousPos;
                        GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>().ThrowBall();
                        GameObject.Find("ArrowController").GetComponent<LineRenderer>().enabled = false;
                    }
                }

                if (isMouseDragging)
                {
                    Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

                    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

                    getTarget.transform.position = new Vector3(Mathf.Clamp(currentPosition.x, -4f, 0f), transform.position.y, Mathf.Clamp(currentPosition.z, -3f, 4f));

                }
            }
        }
    }
}


