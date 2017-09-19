using UnityEngine;

public class barrierDestroy : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
    }

    //與BarrierDestroier物件綁定
    void OnTriggerEnter(Collider e)
    {
        //當BarrierDestroier碰到的是障礙物，消除障礙物，避免障礙物無限增長，耗盡記憶體
        if (e.CompareTag("barrier"))
        {
            Destroy(e.gameObject);
        }
    }
}
