using UnityEngine;
using System.Collections;

public class barrierGenerate : MonoBehaviour {

    public GameObject barrier;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider e)
    {
        if (e.CompareTag("Player"))
        {
            Vector3 planePos = gameObject.transform.parent.position;
            for (int i = 0; i < 10; i += 5)
            {
                Vector3 barrierPos = new Vector3(-3, 1f, Random.Range(planePos.z + 50 + (i * 10), planePos.z + 50 + (i + 5) * 10));
                Instantiate(barrier, barrierPos, transform.rotation);
            }
            for (int i = 0; i < 10; i += 5)
            {
                Vector3 barrierPos = new Vector3(0, 1f, Random.Range(planePos.z + 50 + (i * 10), planePos.z + 50 + (i + 5) * 10));
                Instantiate(barrier, barrierPos, transform.rotation);
            }
            for (int i = 0; i < 10; i += 5)
            {
                Vector3 barrierPos = new Vector3(3, 1f, Random.Range(planePos.z + 50 + (i * 10), planePos.z + 50 + (i + 5) * 10));
                Instantiate(barrier, barrierPos, transform.rotation);
            }
        }
    }
}
