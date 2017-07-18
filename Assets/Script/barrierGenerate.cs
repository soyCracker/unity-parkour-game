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

            for(int i=-3;i<4;i+=3)
            {
                for(int j=0;j<2;j++)
                {
                    int seed = System.Guid.NewGuid().GetHashCode();
                    Random.InitState(seed);
                    Vector3 barrierPos = new Vector3(i, 2.5f, Random.Range(planePos.z + 50 + (j * 50), planePos.z + 100 + (j * 50)));
                    Instantiate(barrier, barrierPos, transform.rotation);
                }
            }
        }
    }
}
