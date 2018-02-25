using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = .5f;

    private Vector3 currentVelocity;

    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x,target.position.y,transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position,newPos, ref currentVelocity,smoothSpeed);
            //Vector3.Lerp(transform.position,newPos,smoothSpeed);
        }
    }

}
