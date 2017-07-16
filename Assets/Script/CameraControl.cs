using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraFollow();
    }


    private void CameraFollow()
    {
        Vector3 expected = new Vector3(0, 7, GameObject.FindWithTag("Player").transform.position.z - 6);
        transform.position = Vector3.Lerp(transform.position, expected, 0.5f);
    }
}
