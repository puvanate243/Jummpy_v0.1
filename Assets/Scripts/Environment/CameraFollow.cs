using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Target;
    public Vector3 offset;

    [SerializeField]
    private float smoothSpeed = 0.125f;

    void LateUpdate()
    {

        Vector3 direction = new Vector3(Target.position.x,0,0);
        Vector3 desiredPosition = direction + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

       
    }
}
