using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public bool rotateObject = true;

    float rotationSpeed = 0.5f;

    public void Update()
    {
        ApplyRotation();
    }

    public void RotateNow()
    {
        //When called changes the bool which determines if the object rotates or not.
        if (rotateObject == true)
        {
            rotateObject = false;

        }else if (rotateObject == false)
        {

            rotateObject = true;
        }
    }

    public void ApplyRotation()
    {
        if (rotateObject == true)
        {
            transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
        }
    }
}
