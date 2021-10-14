using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public AudioSource itemAudio;
    private int count = 0;

    void Start()
    {
        count = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"&&count==0)
        {
            itemAudio.Play();
            count++;
        }
    }
}
