using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureAndBone : ObjectMovement
{
    private float rotateSpeed = 2f;
    protected override void Update() // POLYMORPHISM
    {
        base.Update();
        Rotate();
    }
    void Rotate()
    {
        transform.Rotate(rotateSpeed, rotateSpeed, 0);
    }
}
