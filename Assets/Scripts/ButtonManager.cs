using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Sprite a1;
    public Sprite a2;
    Button a;
    public GameObject Text;
    public static bool Lock=false;

    void Start()
    {
        a = GetComponent<Button>();
    }

    void Update()
    {
        if (!Lock)
        {
            a.image.sprite = a1;
            Text.SetActive(true);
            a.enabled = true;
        }
        else
        {
            a.image.sprite = a2;
            Text.SetActive(false);
            a.enabled = false;
        }
    }

    public static void LockButton()
    {
        Lock = true;
    }
    public static void UnlockButton()
    {
        Lock = false;
    }
}
