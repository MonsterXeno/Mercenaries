using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkScript : MonoBehaviour
{
    public float distance = 5.0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BlinkForward();
        }
    }

    public void BlinkForward()
    {
        RaycastHit hit;
        Vector3 destination = transform.position + transform.forward * distance;
        //obstacles found to be intersecting
        if(Physics.Linecast(transform.position, destination, out hit))
        {
            destination = transform.position + transform.forward * (hit.distance - 1f);
        }

        //no obstacles found yayyyy
        if(Physics.Raycast(destination, -Vector3.up, out hit))
        {
            destination = hit.point;
            destination.y = 0.5f;
            transform.position = destination;
        }
    }
}

