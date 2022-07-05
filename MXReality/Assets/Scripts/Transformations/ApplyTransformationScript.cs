using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ApplyTransformationScript : MonoBehaviour
{
    //This script tracks what desired transformation is to be applied to each object and executes them based on the result of the enum.

    [Header("Object States")]
    public DesiredTransform whatTransformation;

    [Header("Object Managment")]
    //This will will contain every object we need to check the state of in order to change the objects scale.
    public List<GameObject> objectsToCheck = new List<GameObject>();

    public GameObject myToolBox;



    // this Enum contains every possible transformation.
    public enum DesiredTransform {ScaleSize, ChangeColor, RotateObject}

    public void Start()
    {
        ApplyTransformation();
        //Debug.Log("Check Start Function");
    }

    public void OnMouseOver()
    {
        //This function displays the object tooltip when the player mouse hovers over it.
        myToolBox.GetComponent<ToolTipScript>().ShowToolBox();
        myToolBox.GetComponent<ToolTipScript>().hovering = true;
    }
    
    public void OnMouseDown()
    {
        ApplyTransformation();
    }

    public void ApplyTransformation()
    {
        //Declare this game object.
        GameObject attachedObject = gameObject;

        //This function causes a state change in the clicked object depending upon type of desired transformation determined by the enum.
        string applyTransformation = whatTransformation.ToString();

        switch (applyTransformation)
        {
            case "ScaleSize":
                //If the player chooses to interact with the object check for the needed transform script.
                if (GetComponent<ChangeScale>() == null)
                {
                    //If not found attach it to the game object.
                    attachedObject.AddComponent<ChangeScale>();
                    //Set the tooltip of the objects 
                    myToolBox.GetComponent<ToolTipScript>().toolBoxText.text = "This is object 3 - Click to change its size";
                }

                //Call the necessary function.
                GetComponent<ChangeScale>().ChangeObjectSize();

                break;

            case "ChangeColor":

                if (GetComponent<ChangeColor>() == null)
                {
                    attachedObject.AddComponent<ChangeColor>();
                    myToolBox.GetComponent<ToolTipScript>().toolBoxText.text = "This is object 1 - Click to change its colour";
                }

                GetComponent<ChangeColor>().ChangeMaterialColor();
                break;

            case "RotateObject":

                if (GetComponent<RotateObject>() == null)
                {
                    attachedObject.AddComponent<RotateObject>();
                    myToolBox.GetComponent<ToolTipScript>().toolBoxText.text = "This is object 2 - Click to toggle a rotation";
                }

                GetComponent<RotateObject>().RotateNow();
                break;
        }
    }

    public void OnMouseExit()
    {
        //This function hides the object tooltip when the player mouse stops hovering over it.
        myToolBox.GetComponent<ToolTipScript>().HideToolBox();
        myToolBox.GetComponent<ToolTipScript>().hovering = false;
    }
   
}
