using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public GameObject Canvas;


    public void CanvasOn()
    {
        Canvas.SetActive(true);
       
    }
    public void CanvasOff()
    {
        Canvas.SetActive(false);
       
    }
    public void facebook()
    {
        Application.OpenURL("https://www.facebook.com/Daichiz-102456044615330/");
    }

}
