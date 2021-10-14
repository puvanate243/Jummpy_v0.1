using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float speed;
    private bool touch=false;
    private Vector3 SpawnPoint;
    // Use this for initialization
    void Start () {
        SpawnPoint = transform.position;
	}
	
	
	void Update () {
        if (touch)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
        if(transform.position.y < -5f)
        {
            touch = false;
            transform.position = SpawnPoint;
        }
    }
    public void touchOn()
    {
        touch = true;
    }
}
