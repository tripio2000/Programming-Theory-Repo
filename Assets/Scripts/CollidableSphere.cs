using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableSphere : Collidable //INHERITANCE
{
    [SerializeField] AudioSource audioSource;
    protected override void ColliderHit() //POLYMORPHISM
    {
        if (!audioSource.isPlaying) { audioSource.Play(); }
    }
    public override Color GetColor() //POLYMORPHISM
    {
        return Color.grey;
    }
}
