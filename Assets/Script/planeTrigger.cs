using UnityEngine;
using System.Collections;

public class planeTrigger : MonoBehaviour {

    GameObject plane;

    // Use this for initialization
    void Start () {
        plane = new GameObject();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider e)
    {
        if (e.CompareTag("Player"))
        {
            if (gameObject.transform.parent.CompareTag("Plane2"))
            {
                plane = GameObject.FindGameObjectWithTag("Plane1");
                plane.transform.position = new Vector3(0, 0, plane.transform.position.z + 200);
            }
            else
            {
                plane = GameObject.FindGameObjectWithTag("Plane2");
                plane.transform.position = new Vector3(0, 0, plane.transform.position.z + 200);
            }
        }
    }

}
