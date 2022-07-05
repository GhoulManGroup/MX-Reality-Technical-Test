using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Player States")]


    [Header("PlayerMovement")]
    //The speed in which the player moves around the space.
    float movementSpeed = 3f;

    [Header("PlayerComponenets")]
    //The player objects charcter controler component.
    CharacterController playerController;
    
    void Awake()
    {
        //Intialize player values and componenets
        playerController = this.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementFunction();
    }

    public void PlayerMovementFunction()
    {

        //Get axis horiztonal is left and right movement vertical is forward and backwards.
        float XMovement = Input.GetAxis("Horizontal");
        float ZMovement = Input.GetAxis("Vertical");

        //Create a custom vector 3 transformation and feed it the input of get axis.
        Vector3 movementDirection = transform.right * XMovement + transform.forward * ZMovement;

        //Tell the player charctercontroller to apply the transformation stored within vector 3 at the speed of the player movement varible locked to time.deltatime. 
        playerController.Move(movementDirection * movementSpeed * Time.deltaTime);
    }


}
