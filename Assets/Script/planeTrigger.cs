using UnityEngine;
using System.Collections;

public class planeTrigger : MonoBehaviour {

    GameObject Ground;

    // Use this for initialization
    void Start () {
        Ground = new GameObject();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider e)
    {
        if (e.CompareTag("Player"))
        {
            if (gameObject.transform.parent.CompareTag("GroundTwo"))
            {
                Ground = GameObject.FindGameObjectWithTag("GroundOne");
                Ground.transform.position = new Vector3(44, 35.1f, Ground.transform.position.z + 197.6f);
            }
            else
            {
                Ground = GameObject.FindGameObjectWithTag("GroundTwo");
                Ground.transform.position = new Vector3(44, 35.1f, Ground.transform.position.z + 197.6f);
            }
            GameObject.FindGameObjectWithTag("Wave").transform.position += new Vector3(0, 0, 100);
        }
    }

}
