using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour {

   
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float start;
    [SerializeField]
    private float end;
    [SerializeField]
    private bool up;
    [SerializeField]
    private bool goBack;
    [SerializeField]
    private bool IsPlatform;

    private int count = 0;
    private bool PlayerTouch = false;
    
    void Update()
    {
        if (up && !goBack)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime, transform.position.z);
            if (transform.position.y > end)
            {
                transform.position = new Vector3(transform.position.x, start, transform.position.z);
            }
        }
        if (!up && !goBack)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, transform.position.z);
            if (transform.position.y < end)
            {
                transform.position = new Vector3(transform.position.x, start, transform.position.z);
            }
        }
        if (PlayerTouch)
        {
            if (goBack)
            {
                if (count == 0)
                {
                    if (transform.position.y > end)
                        count = 1;
                    transform.position = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime, transform.position.z);

                }
                if (count == 1)
                {
                    if (transform.position.y < start)
                        count = 0;
                    transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, transform.position.z);
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.collider.gameObject != null && IsPlatform)
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
