using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBack;
    private Image joystickFront;
    private Vector2 input;

    private void Start()
    {
        joystickBack = GetComponent<Image>();
        joystickFront = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        input = Vector2.zero;
        joystickFront.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBack.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBack.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBack.rectTransform.sizeDelta.x);

            input = new Vector2(pos.x * 2, pos.y * 2);
            input = (input.magnitude > 1f) ? input.normalized : input;

            joystickFront.rectTransform.anchoredPosition = new Vector2(input.x * (joystickBack.rectTransform.sizeDelta.x / 2), input.y * (joystickBack.rectTransform.sizeDelta.y / 2));

        }
    }

    public float GetHorizontalValues()
    {
        if (input.x != 0)
        {
            return input.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float GetVerticalValues()
    {
        if (input.y != 0)
        {
            return input.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
