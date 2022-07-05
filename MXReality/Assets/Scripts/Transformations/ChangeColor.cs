using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    [Header("ColorChange")]

    public string currentColor = "Green";
    string desiredColor = "Blue";

    Renderer objectRenderer;

    public void ChangeMaterialColor()
    {
        switch (desiredColor)
        {
            case "Blue":
                GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                desiredColor = "Green";
                currentColor = "Blue";
                break;

            case "Green":
                GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                desiredColor = "Blue";
                currentColor = "Green";
                break;
        }

       
    }
}
