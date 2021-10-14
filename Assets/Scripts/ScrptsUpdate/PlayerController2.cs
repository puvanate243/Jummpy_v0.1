using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        Setting();
    }

  
    void Update()
    {
        
    }

    void Setting()
    {
        rb = GetComponent<Rigidbody2D>();



    }
}
