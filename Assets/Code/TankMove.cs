using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    //public CharacterController2D controller;
    //public Animator animator;

    public Joystick joystick;

    public float runSpeed = 0.005f;

    float horizontalMove = 0f;
    float verticalMove = 0f;


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

        if (joystick.Horizontal >= .2f) horizontalMove = runSpeed;
        else if (joystick.Horizontal <= -.2f) horizontalMove = -runSpeed;
        else horizontalMove = 0;


        if (joystick.Vertical >= .2f) verticalMove = runSpeed;
        else if (joystick.Vertical <= -.2f) verticalMove = -runSpeed;
        else verticalMove = 0;

        if (joystick.Horizontal != 0f && joystick.Vertical != 0f)
        {
            float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), 0.01f);
            Debug.Log("angle: " + angle.ToString());
        }

        Vector3 moveVector = new Vector3(horizontalMove, verticalMove, 0);
        transform.position += moveVector;

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
}
