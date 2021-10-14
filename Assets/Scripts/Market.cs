using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour {
    public ButtonManager Button;

    void Start()
    {
        Button = GetComponent<ButtonManager>();
    }
    void Update()
    {
        if (GameManager.hearthOrigin == 5)
        {

            ButtonManager.Lock = true;
        }
    }

    public void AddH()
    {
        if (GameManager.hearthOrigin < 5)
        {
            
            ButtonManager.Lock = false;
            if (CoinsManager.Coins >= 50)
            {
              
                GameManager.hearthOrigin = GameManager.hearthOrigin + 1;
                GameManager.AddHearth(GameManager.hearthOrigin);
                CoinsManager.Coins -= 50;
                PlayerPrefs.SetInt("Coins", CoinsManager.Coins);

            }
            if (GameManager.hearthOrigin == 5)
            {
                
                ButtonManager.Lock = true;
            }
        }
       
    }

}
