using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremePointsAndList : MonoBehaviour {

    public Renderer _rend;
    public List<string> Interacted = new List<string>();
    public float y;

    public void Start()
    {
        _rend = GetComponent<Renderer>();
        y = _rend.bounds.max.y;

    }

	// Update is called once per frame
	void Update () {
    
    }
}
