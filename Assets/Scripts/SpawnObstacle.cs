using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Vector3 startLocation, bounds;
    //[SerializeField] float horizontalSpacing, verticalSpacing;
    [SerializeField] int numberOfObstacles;
    void Start()
    {
        float horizontalPosition=-0.8f*bounds.z;
        float verticalPosition = startLocation.y;
        float direction=-1;
        for (int index = 0; index < numberOfObstacles; index++)
        {
            if (horizontalPosition > bounds.z) //outOfBounds, reset horizontal
            {
                horizontalPosition = -0.8f * bounds.z+direction*0.125f; 
                verticalPosition += 0.5f;
                direction = direction * (-1);
            }
            Instantiate(obstaclePrefab, new Vector3(0f,verticalPosition,horizontalPosition),
                obstaclePrefab.transform.rotation);
            horizontalPosition +=0.5f;
            
        }
    }
}
