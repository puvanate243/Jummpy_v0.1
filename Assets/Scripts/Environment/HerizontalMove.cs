using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerizontalMove : MonoBehaviour {

    [SerializeField]
    private float Speed;
    [SerializeField]
    private float start;
    [SerializeField]
    private float end;
    [SerializeField]
    private bool right;
    [SerializeField]
    private bool goBack;
    [SerializeField]
    private bool IsPlatform;

    private int count=1;
    private bool PlayerTouch = false;
   
    void Update()
    {
        if (right && !goBack)
        {
            transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x > end)
            {
                transform.position = new Vector3(start, transform.position.y, transform.position.z);
            }
        }
        if (!right && !goBack)
        {
            transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x < end)
            {
                transform.position = new Vector3(start, transform.position.y, transform.position.z);
            }
        }
        if (PlayerTouch)
        {
            if (goBack)
            {
                if (count == 0)
                {
                    if (transform.position.x > end)
                        count = 1;
                    transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);

                }
                if (count == 1)
                {
                    if (transform.position.x < start)
                        count = 0;
                    transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
            }
        }

        
        }
    void OnCollisionEnter2D(Collision2D Other)
    {
       if(Other.collider.gameObject != null && IsPlatform)
       {
            Other.collider.transform.SetParent(transform);
       }
       if (Other.collider.gameObject.tag == "Player" && IsPlatform)
       {
            PlayerTouch = true;
       }
    }
    void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.collider.gameObject != null && IsPlatform)
        {
            Other.collider.transform.SetParent(null);
        }
    }


}
   

