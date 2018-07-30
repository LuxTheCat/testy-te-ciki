﻿using System.Collections.Generic;
using UnityEngine;

public class colisinfo : MonoBehaviour
{

    public List<string> Interacted = new List<string>();

    public void OnTriggerEnter(Collider other)
    {
        if (Interacted.Contains(other.gameObject.transform.parent.transform.parent.name))
            Debug.Log("Było już");
        else
        {

            Interacted.Add(other.gameObject.transform.parent.transform.parent.name);

            Debug.Log(other.gameObject.transform.parent.position);

            Debug.Log(other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position));



            other.gameObject.transform.parent.transform.parent.GetComponent<bounds>().Scale.xScale = other.gameObject.transform.parent.transform.parent.transform.localScale.x;
            other.gameObject.transform.parent.transform.parent.GetComponent<bounds>().Scale.yScale = other.gameObject.transform.parent.transform.parent.transform.localScale.y;
            other.gameObject.transform.parent.transform.parent.GetComponent<bounds>().Scale.zScale = other.gameObject.transform.parent.transform.parent.transform.localScale.z;

            //Używane są 4 ścianki w 2D ale może w przyszłości przeniosę do 3D

            if (other.gameObject.transform.parent.name == "x1")
                Debug.Log("x1");

            if (other.gameObject.transform.parent.name == "x2")
                Debug.Log("x2");

            if (other.gameObject.transform.parent.name == "y1")
                Debug.Log("y1");

            if (other.gameObject.transform.parent.name == "y2")
                Debug.Log("y2");

            if (other.gameObject.transform.parent.name == "y3")
                Debug.Log("y3");

            if (other.gameObject.transform.parent.name == "y4")
                Debug.Log("y4");
        }
    }
}
