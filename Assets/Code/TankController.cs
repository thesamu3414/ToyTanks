using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private Vector2 movementJoystickVector;

    public float maxAcceleration = 100f;
    public float breakingForce = 50f;
    public float currentAcceleration = 0f;
    public float currentBreakForce = 0f;
    
    public float maxSpeed = 1.0f;
    public float speedWindow = 0.05f;
    public float baseRotationSpeed = 100.0f;

    public float turretRotationSpeed = 150;
    public float rotationWindow = 2.0f; //Degrees

    public Turret tank_turret;
    public Transform turret_transform;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

     public void HandleShoot()
     {
        tank_turret.Shoot();
     }

    public void HandleTurretMovement(Vector2 pointerDirection)
    {
        // Keep Turret at last angle when aimjoystick is released
        if (pointerDirection.y != 0.0f && pointerDirection.x != 0.0f)
        {
            var angle = Mathf.Atan2(pointerDirection.y, pointerDirection.x) * Mathf.Rad2Deg - 90;

            var rotationStep = turretRotationSpeed * Time.deltaTime;

            turret_transform.rotation = Quaternion.RotateTowards(turret_transform.rotation, Quaternion.Euler(0, 0, angle), rotationStep);
        }
    }

    public void HandleMoveBody(Vector2 leftJoystickVector)
    {
        this.movementJoystickVector = leftJoystickVector;
    }

    private void Rotate_rb2d(float angle)
    {

    float baseRotationStep = baseRotationSpeed * Time.deltaTime;

    // Choose closest path to rotate
    // If difference in [0,180] substract, if not add.
    if (angle > 0.0f) baseRotationStep = -1.0f * baseRotationStep;

    //Debug.Log((angle > 0.0f) ? "substract" : "add");

    rb2d.MoveRotation(rb2d.rotation + baseRotationStep);
    }

    //Method to convert a angle to [-180,180] degrees
    private float angle_to_180(float angle_input)
    {
        float output_angle = angle_input % 360.0f;

        if (output_angle > 180.0f)
        {
            output_angle -= 360.0f;
        }
        else if (output_angle < -180.0f)
        {
            output_angle += 360.0f;
        }

        return output_angle;
    }

    private void FixedUpdate()
    {

        Vector2 wantedPosition = transform.position + (transform.up * maxSpeed * movementJoystickVector.y * Time.deltaTime);
        rb2d.MovePosition(wantedPosition);

        float rotationFactor = 0f;
        if (movementJoystickVector.x >= 0.2)
        {
            rotationFactor = movementJoystickVector.x;
        }
        float wantedRotation = rb2d.rotation +  (baseRotationSpeed * -1f * movementJoystickVector.x * Time.deltaTime);
        rb2d.MoveRotation(wantedRotation);

        /*
        // horizontal component will give magnitud and direction for the rotation
        var baseRotationStep = baseRotationSpeed * Time.deltaTime * -1f * movementVector.x;

        rb2d.MoveRotation(rb2d.rotation + baseRotationStep);


        var TotalAcceleration = currentAcceleration - currentBreakForce;
        Vector2 acceleration = TotalAcceleration * new Vector2( Mathf.Sin(rb2d.rotation * Mathf.Deg2Rad), Mathf.Cos(rb2d.rotation * Mathf.Deg2Rad));

        rb2d.velocity = rb2d.velocity + acceleration * Time.deltaTime;

        //Debug.Log("rb2d rotation: " + rb2d.rotation + " velocity: " + rb2d.velocity+ " acel: " + acceleration);
        // MoveJoystick Angle
        var movementVect_angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;

        Debug.Log("rotation: " + rb2d.rotation + " rotation step: " + baseRotationStep);
        Debug.Log("currentAccel: " + currentAcceleration + "currentBF: " + currentBreakForce + " acceleration: " + acceleration + " velocity: " + rb2d.velocity);
        */

/*
        // Here we are rotating the axis to make out movementVect_angle on of them (0 degrees)
        var diff_rb2d_movem_angle = (rb2d.rotation + 90.0f - movementVect_angle);
        // Make it now between [-180,180]
        diff_rb2d_movem_angle = angle_to_180(diff_rb2d_movem_angle);

        
        Debug.Log("movementVect_angle: " + movementVect_angle + " rb2d rotation: " + (rb2d.rotation + 90) % 360 + " diff: " + diff_rb2d_movem_angle);
        if (diff_rb2d_movem_angle <= rotationWindow && diff_rb2d_movem_angle >= -rotationWindow)
        {
            rb2d.velocity = movementVector * maxSpeed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = new Vector2(0.0f, 0.0f);

            var baseRotationStep = baseRotationSpeed * Time.deltaTime;

            // Choose closest path to rotate
            // If difference in [0,180] substract, if not add.
            if (diff_rb2d_movem_angle > 0.0f) baseRotationStep = -1.0f * baseRotationStep;

            Debug.Log((diff_rb2d_movem_angle > 0.0f) ? "substract" : "add");

            rb2d.MoveRotation(rb2d.rotation + baseRotationStep);

        }
        */
    }
}
