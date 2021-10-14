using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour {

    public static int Coins;
    Text txt;
    void Start()
    {

        Coins = PlayerPrefs.GetInt("Coins", Coins);
        txt = GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>();
        txt.text = "Coins : " + CoinsManager.Coins;
        
    }
    void Update()
    {
        txt = GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>();
        txt.text = "Coins : " + CoinsManager.Coins;
    }

    public static void AddCoin()
    {
       Coins+=1;
        PlayerPrefs.SetInt("Coins", Coins);
  
    }
    public static void CoinReset()
    {
        Coins = 0;
        PlayerPrefs.SetInt("Coins", Coins);
    }
}
