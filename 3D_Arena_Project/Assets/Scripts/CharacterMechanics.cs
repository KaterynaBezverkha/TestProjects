using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    public float moveSpeed;
    public float rotationAmount;

    private Vector3 moveVector;

    private CharacterController ch_control;
    private JoystickController j_control;
    private RightPadController r_control;

    // Start is called before the first frame update
    void Start()
    {
        ch_control = GetComponent<CharacterController>();
        j_control = GameObject.FindGameObjectWithTag("Joystick").GetComponent<JoystickController>();
        r_control = GameObject.FindGameObjectWithTag("RightPad").GetComponent<RightPadController>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        CharacterRotate();
    }

    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = j_control.GetHorizontalValues() * moveSpeed;
        moveVector.z = j_control.GetVerticalValues() * moveSpeed;

        ch_control.Move(moveVector * Time.deltaTime);
    }

    private void CharacterRotate()
    {
        transform.Rotate(Vector3.up, r_control.rot*rotationAmount*Time.deltaTime);
    }

}
