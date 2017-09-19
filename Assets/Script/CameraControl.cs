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
        //相機的期望位置=搜索人物的位置Z軸-6
        Vector3 expected = new Vector3(0, 7, GameObject.FindWithTag("Player").transform.position.z - 6);
        //讓相機跟著人物線性移動
        transform.position = Vector3.Lerp(transform.position, expected, 0.5f);
    }
}
