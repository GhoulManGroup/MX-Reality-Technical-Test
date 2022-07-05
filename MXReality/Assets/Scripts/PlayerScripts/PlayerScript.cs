using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [Header("PlayerMovement")]
    //The speed in which the player moves around the space.
    float movementSpeed = 4f;

    [Header("PlayerComponenets")]
    //The player objects charcter controler component.
    CharacterController playerController;

    [SerializeField]
    public Canvas myCanvas;
    private CanvasGroup myGroup;

    public bool cursorHovering;
    
    void Awake()
    {
        //Intialize player values and componenets
        playerController = this.GetComponent<CharacterController>();

        myGroup = myCanvas.GetComponent<CanvasGroup>();
        if (myGroup != null)
        {
            myGroup.alpha = 0.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementFunction();
        Debug.Log(cursorHovering);
        if (cursorHovering == false && myGroup.alpha > 0.25)
        {
            HideCursor();
        }
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

    public void HideCursor()
    {
        StartCoroutine(fadeBox(false));
    }

    public void ShowCursor()
    {
        StartCoroutine(fadeBox(true));

    }

    private IEnumerator fadeBox(bool hide)
    {
        if (hide)
        {
           myGroup.alpha += Time.deltaTime;
            yield return new WaitUntil(() => myGroup.alpha == 1);
        }
        else
        {
           myGroup.alpha -= Time.deltaTime;
            yield return new WaitUntil(() => myGroup.alpha == 0.25f);
        }

        yield return null;
    }


}
