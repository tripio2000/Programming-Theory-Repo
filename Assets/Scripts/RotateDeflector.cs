using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDeflector : MonoBehaviour
{ 
    enum Direction {clockwise, counterclockwise}
    [SerializeField] Direction direction;
    float currentAngle = 90;
    void Update()
    {
        float value = ReadInput();
        if (value != 0)
        {
            Rotate(value * 1f, direction);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity = new Vector3(0, 0,-9.81f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }
    float ReadInput()
    {
        return Input.GetAxis("Vertical");
    }
    void Rotate(float increment, Direction direction)
    {
        short directionMultiplier;
        switch (direction)
        {
            case Direction.clockwise:
                directionMultiplier = -1;
                break;
            case Direction.counterclockwise:
                directionMultiplier = 1;
                break;
            default:
                directionMultiplier = 0;
                break;
        }
        gameObject.transform.RotateAround(transform.position, Vector3.right, directionMultiplier*increment);
    }
}
