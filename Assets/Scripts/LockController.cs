using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockController : MonoBehaviour
{
    public Sprite a1;
    public Sprite a2;
    public Button a;
    public GameObject num;
    public int Scene;
    // Use this for initialization
    void Update()
    {

        if (GameManager.sceneLock>= Scene-1)
        {
            a.image.sprite = a1;
            num.SetActive(true);
            a.enabled = true;
        }
        else
        {
            a.image.sprite = a2;
            num.SetActive(false);
            a.enabled = false;
        }
    }
  
}
