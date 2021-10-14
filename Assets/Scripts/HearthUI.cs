using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthUI : MonoBehaviour {

    public GameObject hearthUI;

    private int temp = 0;
    private int c=0;
    GameObject h;

    void Update()
    {
        h = GameObject.FindGameObjectWithTag("Hearth");
      
        if (GameManager.hearth < temp)
        {
            damaged();
            temp = GameManager.hearth;
            c++;
        }
    }
  
    public void createHeart() {

        for (int i = 0; i < GameManager.hearth; i++)
            {
           
            GameObject newHearth = Instantiate(hearthUI, transform.position, transform.rotation) as GameObject;
            newHearth.transform.SetParent(GameObject.FindGameObjectWithTag("HearthCanvas").transform, false);
           
        }
        temp = GameManager.hearth;
    }
    void damaged() {
     
      
        Destroy(h.gameObject);
       
    }
 
   
}
