using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Sprite b1;
    public Sprite b2;
    Button b;
    // Use this for initialization
    void Start()
    {
        b = GameObject.Find("/Canvas/Sound").GetComponent<Button>();
        if (!GameManager.lSound)
        {
            b.image.sprite = b2;
        }
        else
        {
            b.image.sprite = b1;
        }
    }
    public void SoundSwitch()
    {
        GameManager.lSound = !GameManager.lSound;
        AudioListener.pause = GameManager.lSound;
        if (!GameManager.lSound)
        {
            b.image.sprite = b2;
        }
        else
        {
            b.image.sprite = b1;
        }
    }
}
