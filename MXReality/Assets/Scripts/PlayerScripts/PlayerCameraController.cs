using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the camera object attached as a child to the player object.
public class PlayerCameraController : MonoBehaviour
{
    // How quick the camera moves in responce to the mouse movement.
    public float mouseSpeed;

    float RotationX = 0f;

    //This public transform rotates the player left and right matching the mouse movement on the x axis so their body is always forward.
    public Transform playerBody;

    public void Start()
    {
        //Lock player cursor.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the player camera and body to follow the mouse input.
        PlayerLookFunction();
    }

    public void PlayerLookFunction()
    {

        //Store the positions of our mouse in two varibles.
        float XMousePosition = Input.GetAxis("Mouse X") * mouseSpeed;
        float YMousePosition = Input.GetAxis("Mouse Y") * mouseSpeed;

        //Restrict how far we can rotate the camera up and down.
        RotationX -= YMousePosition;
        RotationX = Mathf.Clamp(RotationX, -90f, 90f);

        //Rotate the camera to face the mouse.
        //transform.localRotation = Quaternion.Euler(xRotation * Time.deltaTime, 0, 0);

        transform.localRotation = Quaternion.Euler(RotationX, 0f, 0f);

        //Rotate the player left and right depending on the direction the cursor moves.
        playerBody.Rotate(Vector2.up * XMousePosition);
    }

}
