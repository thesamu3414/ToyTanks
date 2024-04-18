using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    public Joystick joystick;

    //public float runSpeed = 0.005f;

    float aim_X = 0f;
    float aim_Y = 0f;
    float aim_angle = 0f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            transform.position = touchPosition;
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        } */

        //if (Mathf.Abs(joystick.Horizontal) >= .2f) aim_X = joystick.Horizontal;
        ////else if (joystick.Horizontal <= -.2f) aim_X = -joystick.Horizontal;
        //else aim_X = 0;


        //if (Mathf.Abs(joystick.Horizontal) >= .2f) aim_Y = joystick.Vertical;
        ////else if (joystick.Horizontal <= -.2f) aim_Y = -joystick.Vertical;
        //else aim_Y = 0;

        if ( joystick.Horizontal != 0f && joystick.Vertical != 0f)
        {
            aim_X = joystick.Horizontal;
            aim_Y = joystick.Vertical;
        }

        aim_angle = Mathf.Atan2(aim_Y, aim_X) * Mathf.Rad2Deg;
        //Debug.Log("angle: " + aim_angle.ToString());
        transform.eulerAngles = new Vector3(0,0,aim_angle - 90);

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
}
