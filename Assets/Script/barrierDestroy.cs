﻿using UnityEngine;
using System.Collections;

public class barrierDestroy : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
    }

    void OnTriggerEnter(Collider e)
    {
        if (e.CompareTag("barrier"))
        {
            Destroy(e.gameObject);
        }
    }
}
