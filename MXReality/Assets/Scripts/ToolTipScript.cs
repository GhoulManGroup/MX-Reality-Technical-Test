using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipScript : MonoBehaviour
{
    public Canvas myCanvas;
    private CanvasGroup myGroup;
    public Text toolBoxText;

    public bool hovering;

    public void Start()
    {
       
        myGroup = myCanvas.GetComponent<CanvasGroup>();
        if (myGroup != null)
        {
            myGroup.alpha = 0;
        }

    }

    public void Update()
    {
        if (hovering == false && myGroup.alpha > 0)
        {
            HideToolBox();
        }
    }

    public void HideToolBox()
    {
        StartCoroutine(fadeBox(false));
    }

    public void ShowToolBox()
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
            yield return new WaitUntil(() => myGroup.alpha == 0);
        }

        yield return null;
    }
}
