using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 2f;
    public float deceleration = 2f;
    public float stopTime = 1f;

    private bool movingForward = true;
    private float currentSpeed = 0f;
    private float currentStopTime = 0f;

    public enum Direction
    {
        Horizontal,
        Vertical
    }
    public Direction direction = Direction.Horizontal;
    public float cycleTime = 5f;
    private float currentCycleTime = 0f;
    public float horizontalAcceleration = 2f;
    public float verticalAcceleration = 2f;
    private bool hasMoved = false;

    void Update()
    {
        if (!hasMoved && transform.position.x > 0f)
        {
            hasMoved = true;
            movingForward = false;
            currentSpeed = 0f;
        }
        if (movingForward)
        {
            currentSpeed += acceleration * Time.deltaTime;
            if (currentSpeed > speed)
            {
                currentSpeed = speed;
            }
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;
            if (currentSpeed < 0f)
            {
                currentSpeed = 0f;
            }
        }

        if (direction == Direction.Horizontal)
        {
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
        }

        if (transform.position.x > 10f && movingForward)
        {
            movingForward = false;
            currentSpeed = 0f;
        }
        else if (transform.position.x < -10f && !movingForward)
        {
            movingForward = true;
            currentSpeed = 0f;
            currentStopTime = 0f;
        }

        if (!movingForward)
        {
            currentStopTime += Time.deltaTime;
            if (currentStopTime > stopTime)
            {
                movingForward = true;
                currentSpeed = 0f;
                currentStopTime = 0f;
            }
        }
        currentCycleTime += Time.deltaTime;
        if (currentCycleTime > cycleTime)
        {
            currentCycleTime = 0f;
            if (direction == Direction.Horizontal)
            {
                direction = Direction.Vertical;
            }
            else
            {
                direction = Direction.Horizontal;
            }
        }
        if (direction == Direction.Horizontal)
        {
            currentSpeed += horizontalAcceleration * Time.deltaTime;
            if (currentSpeed > speed)
            {
                currentSpeed = speed;
            }
            else if (currentSpeed < 0f)
            {
                currentSpeed = 0f;
            }
        }
        else
        {
            currentSpeed += verticalAcceleration * Time.deltaTime;
            if (currentSpeed > speed)
            {
                currentSpeed = speed;
            }
            else if (currentSpeed < 0f)
            {
                currentSpeed = 0f;
            }
        }
    }
}
