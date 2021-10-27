using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetection : MonoBehaviour
{
    GameObject getTarget = null; //target for clicking (cube)
    bool isMouseDragging;
    GameObject ball = null;

    Vector3 previousPos;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    private void Start()
    {
        previousPos = transform.position; //position of cube at start
        ball = GameController.instance.FindBall();
    }

    GameObject ReturnClickedObject(out RaycastHit hit) //getting clicked object (cube)
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
            ball = GameController.instance.FindBall(); //creating a new ball if the previoius one was destroyed
        }
        else 
        {
            if (!BallScript.instance.isBallThrown)  //checking if the ball has been thrown or not
            {

                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hitInfo;
                    getTarget = ReturnClickedObject(out hitInfo);

                    if (hitInfo.collider == null) //checking if player hasn't clicled at collider
                    {
                        getTarget = null;
                    }
                    else if (getTarget.transform.name == "Player") //if player clicked at cube collider
                    {
                        GameObject.Find("ArrowController").GetComponent<LineRenderer>().enabled = true; //enable arrow 
                        isMouseDragging = true; //enable dragging
                        positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position); 
                        offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z)); //getting offset value for cube moving
                    }
                }

                if (Input.GetMouseButtonUp(0) && getTarget!=null) //cheching if player 'unckicked' the cube
                {
                    if (getTarget.transform.name == "Player") 
                    {
                        isMouseDragging = false; //disable dragging
                        transform.position = previousPos; //return the cube to the start position
                        GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>().ThrowBall(); //make the ball move
                        GameObject.Find("ArrowController").GetComponent<LineRenderer>().enabled = false; //disable arrow
                    }
                }

                if (isMouseDragging) //moving the cube with mouse (or touch)
                {
                    Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

                    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

                    getTarget.transform.position = new Vector3(Mathf.Clamp(currentPosition.x, -4f, 0f), transform.position.y, Mathf.Clamp(currentPosition.z, -3f, 4f));

                }
            }
        }
    }
}


