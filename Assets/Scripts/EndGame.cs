using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour {

    Text txtwin;
    public GameObject Botton;

    void Start()
    {
        if (GameManager.sceneNow == 4)
        {
            Botton.SetActive(false);
        }
    }

    void Update()
    {
       

        if (GameManager.win == true && GameManager.TxtCount == 1)
        {

            txtwin = GameObject.Find("/Canvas/win").GetComponent<Text>();
            txtwin.text = "YOU WIN!";


            if (GameManager.sceneLock < GameManager.sceneNow)
            {
                GameManager.sceneLock = GameManager.sceneNow;
                GameManager.AddSceneLock(GameManager.sceneLock);
            }
            GameManager.TxtCount++;

        }
        if(GameManager.win == false && GameManager.TxtCount == 1)
        {

            txtwin = GameObject.Find("/Canvas/win").GetComponent<Text>();
            txtwin.text = "GAME OVER!";
            Botton.SetActive(false);
            GameManager.TxtCount++;
        }
        
        Text txt;
        txt = GameObject.Find("/Canvas/TxtTime").GetComponent<Text>();
        txt.text = "Time : " + GameManager.secondsCount;
    }
   
  
}
