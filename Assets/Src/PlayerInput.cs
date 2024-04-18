using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{

    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveTank = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    public Joystick AimJoystick;
    public Joystick MoveJoystick;
    public ShootButton ShootButton;

    // Update is called once per frame
    void Update()
    {
        GetMovement();
        GetTurretAim();
        GetShootingInput();
    }

    private void GetShootingInput()
    {
        if (GetButtonState())
        {
            OnShoot?.Invoke();
        }
    }
    private void GetTurretAim()
    {
        OnMoveTurret?.Invoke(GetAimJoystickDirection());
    }

    private Vector2 GetAimJoystickDirection()
    {
        Vector2 AimDirection = AimJoystick.Direction;
        return AimDirection;
    }    
    
    private void GetMovement()
    {
        Vector2 moveVector = MoveJoystick.Direction;
        OnMoveTank?.Invoke(moveVector.normalized);
    }

    private bool GetButtonState()
    {
        return ShootButton.buttonPressed;
    }







}
