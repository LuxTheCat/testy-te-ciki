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

    public void Update()
    {
<<<<<<< HEAD
      
    }

}
=======
        Debug.Log(Scale.xScale);
        /*  
            Debug.Log(x1.transform.position);
            Debug.Log(x2.transform.position);
            Debug.Log(x3.transform.position);
            Debug.Log(x4.transform.position);
            Debug.Log(y1.transform.position);
            Debug.Log(y2.transform.position);
            Debug.Log(y3.transform.position);
            Debug.Log(y4.transform.position);
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
>>>>>>> f6d5adcf7cb172d334c1a5923d6601c9349b23d7
