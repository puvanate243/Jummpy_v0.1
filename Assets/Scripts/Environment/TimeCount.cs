using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour {
    float time = 0;
    void Update()
    {

        time += Time.deltaTime;
        int secound = (int)(time);
        GameManager.secondsCount = secound;
        Text txt;
        txt = GameObject.Find("/Canvas/TxtTime").GetComponent<Text>();
        txt.text = "Time : " + GameManager.secondsCount;

    }
}
