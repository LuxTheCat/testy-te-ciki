using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bounds : MonoBehaviour
{
    public Renderer rend;

    public GameObject x1;
    public GameObject x2;

    public GameObject y1;
    public GameObject y2;
    public GameObject y3;
    public GameObject y4;

    public BoxScale Scale;

    public float skalaX;

    public struct BoxScale
    {
        public float xScale;
        public float yScale;
        public float zScale;
    }

    void Start()
    {
        BoxScale Scale = new BoxScale
        {
            xScale = transform.localScale.x,
            yScale = transform.localScale.y,
            zScale = transform.localScale.z
        };
    }

}
