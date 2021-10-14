using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class item : MonoBehaviour
{
    public AudioSource AAudio;
    Text txt;

  
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
        
            CoinsManager.AddCoin();
            
            txt = GameObject.Find("/Canvas/Coins").GetComponent<Text>();
            txt.text = "Coin : " + CoinsManager.Coins;

            AAudio.Play();
            Destroy(gameObject, 0f);
                      
        }

    }



}