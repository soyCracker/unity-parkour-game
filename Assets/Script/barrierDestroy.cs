using UnityEngine;
using System.Collections;

public class barrierDestroy : MonoBehaviour {

    public float movespeed = 1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(gameUI.gameActiveState)
        {
            transform.Translate(Vector3.forward * movespeed);
        }       
    }

    void OnTriggerEnter(Collider e)
    {
        if (e.CompareTag("Barrier"))
        {
            Destroy(e.gameObject);
        }
    }
}
