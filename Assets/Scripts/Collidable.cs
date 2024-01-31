using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all collidable objects
/// </summary>
[RequireComponent(typeof(Collider))]
public abstract class Collidable : MonoBehaviour 
{
    //override to offer the object own color.
    public virtual Color GetColor()
    {
        return Color.black;
    }
    /// <summary>
    /// Override this function to implement what should happen when collider is hit.
    /// </summary>
    protected abstract void ColliderHit();
    private void OnCollisionEnter(Collision collision)
    {
        ColliderHit();
    }
}
