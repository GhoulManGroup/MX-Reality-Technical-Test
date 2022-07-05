using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    //What is the current state of this object.
    string objectSize = "Small";

    float sizeSmall;
    float sizeBig;

    //Is the condition of our transform met.
    bool conditionsMet = false;
    bool applyChange = false;

    public void Start()
    {
        //Set the sizes we want the object to be both smallest and largest.
        sizeSmall = transform.localScale.y;
        sizeBig = transform.localScale.y * 2;
    }

    public void Update()
    {
        // run the apply size change function which will only work when the conditions of changeobjectsize are met.
        ApplySizeChange();
    }

    public void ChangeObjectSize()
    {
        // Only allow this to be pressed if the object isnt changing its size already.
        if (applyChange == false)
        {
            // check object size currently.
            if (objectSize == "Small")
            {
                // check conditions
                CheckConditions();

                // if conditions are met proceed;
                if (conditionsMet == true)
                {
                    applyChange = true;
                }
                else
                {
                    //prevent object changing size
                    applyChange = false;
                }

            }
            else if (objectSize == "Large")
            {
                //Large is always supposed to shrink does not need condition check.
                applyChange = true;
            }
        }
    }

    public void CheckConditions()
    {
        ApplyTransformationScript CurrentObject = GetComponent<ApplyTransformationScript>();

        // Check that both objects in the list have the expected scripts.
        if (CurrentObject.objectsToCheck[0].GetComponent<ChangeColor>() != null && CurrentObject.objectsToCheck[1].GetComponent<RotateObject>() != null)
        {
            // then check that both objects are in the expected state.
            if (CurrentObject.objectsToCheck[0].GetComponent<ChangeColor>().currentColor == "Green" && CurrentObject.objectsToCheck[1].GetComponent<RotateObject>().rotateObject == false)
            {              
                conditionsMet = true;
            }else
            {
                conditionsMet = false;
            }
        }
    }

    public void ApplySizeChange()
    {
        if (applyChange == true)
        {
            //When object is small enlarge it over time.
            if (objectSize == "Small")
            {
                transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
                //When object is larger than 2 * its starting size stop.
                if (transform.localScale.y >= sizeBig)
                {
                    objectSize = "Large";
                    transform.localScale = new Vector3(sizeBig, sizeBig, sizeBig);
                    applyChange = false;
                }
            }

            if (objectSize == "Large")
            {
                transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
                if (transform.localScale.y <= sizeSmall)
                {
                    objectSize = "Small";
                    transform.localScale = new Vector3(sizeSmall, sizeSmall, sizeSmall);
                    applyChange = false;
                }
            }
        }
    }

}
